using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Carousel> Carousels { get; set; }
    }
}
