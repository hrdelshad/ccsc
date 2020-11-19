﻿using System.Diagnostics;
using ccsc.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ccsc.Web.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Dashboard()
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
