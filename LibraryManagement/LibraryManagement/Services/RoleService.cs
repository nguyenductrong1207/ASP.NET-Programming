using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _userManager;

		public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async Task<List<string>> GetAllRolesAsync()
		{
			return await _roleManager.Roles.Select(r => r.Name).ToListAsync();
		}

		public async Task<bool> IsUserInRoleAsync(string userId, string role)
		{
			var user = await _userManager.FindByIdAsync(userId);
			return await _userManager.IsInRoleAsync(user, role);
		}
	}
}
