using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
	public class BookService : IBookService
	{
		private readonly LibraryDbContext _context;

		public BookService(LibraryDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			return await _context.Books.FindAsync(id);
		}

		public async Task<Book> CreateBookAsync(Book book)
		{
			_context.Books.Add(book);
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task UpdateBookAsync(Book book)
		{
			_context.Entry(book).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}
	}
}
