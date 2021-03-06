﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class TestController : Controller
	{
		private IVideoService _videoService;

		public TestController(IVideoService videoService)
		{
			_videoService = videoService;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult VideoSubSystems(int id)
		{
			_videoService.GetSubSystemsOfVideo(id);
			return (Ok());
		}
	}
}
