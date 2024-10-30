using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Dashboard()
		{
			return View();
		}

		public IActionResult Book()
		{
			return View();
		}

		public IActionResult Author()
		{
			return View();
		}

		public IActionResult Category()
		{
			return View();
		}
	}
}
