using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        //public readonly BookContext _BookContext;

        //public BookController(BookContext context)
        //{
        //    _BookContext = context;
        //}

        //public IActionResult ShowBookListFromDb()
        //{
        //    var books = _BookContext.Book.ToList(); 
        //    ViewBag.Books = books;
        //    return View();
        //}

        private readonly LibraryDbContext _LibraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookDetail()
        {
            return View();
        }

        public IActionResult List(string category)
        {
            var books = _LibraryDbContext.Books
                .Where(b => b.Category.Title.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(b => b.BookId)
                .ToList();
            ViewBag.Books = books;
            ViewBag.Category = category;
            return View();
        }
    }
}
