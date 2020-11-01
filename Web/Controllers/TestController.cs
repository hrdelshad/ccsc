using Microsoft.AspNetCore.Mvc;

namespace ccsc.Web.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
