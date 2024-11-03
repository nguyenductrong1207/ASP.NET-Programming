using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryDbContext _LibraryDbContext;

        public HomeController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        public IActionResult Index()
        {
            var carouselItems = _LibraryDbContext.Carousels
           .Where(c => c.IsActive)
           .OrderBy(c => c.Order)
           .ToList();

            var bookList = _LibraryDbContext.Books
               .ToList(); 

            var viewModel = new HomeViewModel 
            {
                CarouselItems = carouselItems,
                Books = bookList
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
