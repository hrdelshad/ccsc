using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.DTOs;
using ccsc.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class ConfigsController : Controller
	{
		private ITfsService _service;

		public ConfigsController(ITfsService service)
		{
			_service = service;
		}
	}
}
