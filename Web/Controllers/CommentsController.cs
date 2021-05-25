using System.Threading.Tasks;
using ccsc.DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Web.Controllers
{
	public class CommentsController : Controller
	{
		private readonly CcscContext _context;

		public CommentsController(CcscContext context)
		{
			_context = context;
		}
		// GET
		public async Task<IActionResult> Index()
		{
			return View(await _context.Comments.ToListAsync());
		}
	}
}