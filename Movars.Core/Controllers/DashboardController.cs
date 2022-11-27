using Microsoft.AspNetCore.Mvc;

namespace Movars.Core.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult NewRequest()
		{
			return View();
		}
	}
}
