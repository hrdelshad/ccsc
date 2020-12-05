using Microsoft.AspNetCore.Mvc;
using ccsc.Core.Services.Interfaces;

namespace ccsc.Web.Controllers
{
	public class Test : Controller
	{
		private IVideoService _videoService;

		public Test(IVideoService videoService)
		{
			_videoService = videoService;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult VideoSubSystems(int id)
		{
			_videoService.GetSubSystemsForVideo(id);
			return (Ok());
		}
	}
}
