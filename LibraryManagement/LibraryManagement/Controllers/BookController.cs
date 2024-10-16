using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
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
