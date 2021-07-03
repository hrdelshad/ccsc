using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Web.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
	{
		#region index

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Dashboard()
		{
			return View();
		}
		#endregion
	}
}
