using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult SignUp()
		{
			return View();
		}
	}
}
