using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
	public class AdminController : Controller
    {
		[Authorize(Roles = "Admin")]
		public IActionResult Dashboard()
		{
			return View();
		}
    }
}
