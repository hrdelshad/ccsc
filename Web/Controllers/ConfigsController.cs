using System.Collections.Generic;
using System.Threading.Tasks;
using ccsc.Core.DTOs;
using ccsc.Core.Services;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Web.Controllers
{
	//[Authorize]
	public class ConfigsController : Controller
	{
		private ITfsService _service;

		public ConfigsController(ITfsService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var res = await _service.GetChangeSets();
			var newChangeSets = res;
			
			//return View(newChangeSets);
			return View((IEnumerable<TfsChangeSetViewModel>) newChangeSets);
		}

	}
}
