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

        public IActionResult List()
        {
            //List<Book> bookList = new List<Book>
            //{
            //    new Book { Title = "The Pragmatic Programmer", Description = "Andrew Hunt" },
            //    new Book { Title = "Clean Code", Description = "Robert C. Martin" },
            //    new Book { Title = "Design Patterns", Description = "Erich Gamma" },
            //    new Book { Title = "Introduction to Algorithms", Description = "Thomas H. Cormen" },
            //    new Book { Title = "The Art of Computer Programming", Description = "Donald E. Knuth" }
            //};

            var books = _LibraryDbContext.Books.OrderBy(b => b.BookId).ToList(); // LinQ

            ViewBag.Books = books;
            return View();
        }
    }
}
