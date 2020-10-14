using ccsc.DataLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace ccsc.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ChangesController : ControllerBase
	{
		private readonly CcscContext _context;

		public ChangesController(CcscContext context)
		{
			_context = context;
		}

		public IActionResult GetChanges()
		{
			return new ObjectResult(_context.ChangeSets);
		}
	}
}
