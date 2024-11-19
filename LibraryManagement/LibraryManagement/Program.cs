using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LibraryManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework and Identity services
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

// Configure Identity services with default settings
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<LibraryDbContext>()
	.AddSignInManager<SignInManager<IdentityUser>>()
	.AddDefaultTokenProviders();

// Register RoleService and BookService for Dependency Injection
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IBookService, BookService>();

// Configure session settings for Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true; // Security setting to prevent XSS attacks
});

// Add Google authentication services
builder.Services.AddAuthentication()
	.AddGoogle(options =>
	{
		// Get these values from Google Developer Console (https://console.developers.google.com)
		options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
		options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
		options.CallbackPath = "/signin-google";  // This must match the URI registered in Google Cloud Console
	});

var app = builder.Build();

// Seed the admin user and roles
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
		var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
		await SeedAdminUser(userManager, roleManager);
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error seeding admin user: {ex.Message}");
	}
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middleware
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Method to seed the admin user and role
static async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
	const string adminEmail = "admin@gmail.com";
	const string adminPassword = "Admin@123";

	// Create Admin Role if it doesn't exist
	if (!await roleManager.RoleExistsAsync("Admin"))
	{
		await roleManager.CreateAsync(new IdentityRole("Admin"));
	}

	// Create Admin User if it doesn't exist
	if (await userManager.FindByEmailAsync(adminEmail) == null)
	{
		var adminUser = new IdentityUser
		{
			UserName = adminEmail,
			Email = adminEmail,
			EmailConfirmed = true
		};

		var result = await userManager.CreateAsync(adminUser, adminPassword);
		if (result.Succeeded)
		{
			// Assign Admin Role to the User
			await userManager.AddToRoleAsync(adminUser, "Admin");
		}
	}
}