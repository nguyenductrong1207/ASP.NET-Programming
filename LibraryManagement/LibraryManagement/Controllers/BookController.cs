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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookDetail()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Book> bookList = new List<Book>
            {
                new Book { NameBook = "The Pragmatic Programmer", Author = "Andrew Hunt" },
                new Book { NameBook = "Clean Code", Author = "Robert C. Martin" },
                new Book { NameBook = "Design Patterns", Author = "Erich Gamma" },
                new Book { NameBook = "Introduction to Algorithms", Author = "Thomas H. Cormen" },
                new Book { NameBook = "The Art of Computer Programming", Author = "Donald E. Knuth" }
            };

            ViewBag.Books = bookList;
            return View();
        }
    }
}
