using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _LibraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookDetail(int id)
        {
            var book = _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult List(string category)
        {
            List<Book> books = _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Category != null && b.Category.Name.ToLower() == category.ToLower())
                .OrderBy(b => b.BookId)
                .ToList();

            ViewBag.Books = books;
            ViewBag.Category = category;
            return View();
        }

        public IActionResult ReadPdf(int id)
        {
            var book = _LibraryDbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null || string.IsNullOrEmpty(book.Pdf))
            {
                return NotFound("This book has not have the PDF version.");
            }

            var pdfUrl = Url.Content($"/{book.Pdf}");
            ViewBag.PdfPath = pdfUrl;
            ViewBag.Title = book.Title;

            return View();
        }

    }
}
