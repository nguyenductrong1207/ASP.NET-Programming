using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class AdminController : Controller
    {
		public IActionResult Dashboard()
		{
			return View();
		}
    }
}
