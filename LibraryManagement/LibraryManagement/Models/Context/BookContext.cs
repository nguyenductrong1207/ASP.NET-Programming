using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        {
        }

        public DbSet<Book> Book {  get; set; }
    }
}
