using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetBooks() => Ok(await _bookService.GetAllBooksAsync());

		[HttpPost]
		public async Task<ActionResult<Book>> CreateBook(Book book) => Ok(await _bookService.CreateBookAsync(book));

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook(int id, Book book)
		{
			if (id != book.BookId) return BadRequest();
			await _bookService.UpdateBookAsync(book);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(int id)
		{
			await _bookService.DeleteBookAsync(id);
			return NoContent();
		}
	}

}
