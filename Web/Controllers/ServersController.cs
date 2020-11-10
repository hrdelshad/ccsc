using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class ServersController : Controller
	{
		private readonly CcscContext _context;

		public ServersController(CcscContext context)
		{
			_context = context;
		}

		// GET: Servers
		public async Task<IActionResult> Index(string searchString)
		{
				var entity = _context.Servers.Include(s => s.Customer).Include(s => s.Os).Include(s => s.ServerType);
			if (!String.IsNullOrEmpty(searchString))
			{
				entity = _context.Servers
					.Where(e => e.Url.Contains(searchString) || 
				                                     e.UserName.Contains(searchString) || 
				                                     e.Password.Contains(searchString) ||
				                                     e.Customer.Title.Contains(searchString))
					.Include(s => s.Customer)
					.Include(s => s.Os)
					.Include(s => s.ServerType);
			}

			return View(await entity.ToListAsync());
		}

		// GET: Servers/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var server = await _context.Servers
				.Include(s => s.Customer)
				.Include(s => s.Os)
				.Include(s => s.ServerType)
				.FirstOrDefaultAsync(m => m.ServerId == id);
			if (server == null)
			{
				return NotFound();
			}

			return View(server);
		}

		// GET: Servers/Create
		public IActionResult Create()
		{
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title");
			ViewData["OsId"] = new SelectList(_context.Oses, "OsId", "Title");
			ViewData["ServerTypeId"] = new SelectList(_context.ServerTypes, "ServerTypeId", "Title");
			return View();
		}

		// POST: Servers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ServerId,ServerTypeId,OsId,Ram,Cpu,Hard,Url,UserName,Password,Vpn,CustomerId")] Server server)
		{
			if (ModelState.IsValid)
			{
				_context.Add(server);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", server.CustomerId);
			ViewData["OsId"] = new SelectList(_context.Oses, "OsId", "Title", server.OsId);
			ViewData["ServerTypeId"] = new SelectList(_context.ServerTypes, "ServerTypeId", "Title", server.ServerTypeId);
			return View(server);
		}

		// GET: Servers/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var server = await _context.Servers.FindAsync(id);
			if (server == null)
			{
				return NotFound();
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", server.CustomerId);
			ViewData["OsId"] = new SelectList(_context.Oses, "OsId", "Title", server.OsId);
			ViewData["ServerTypeId"] = new SelectList(_context.ServerTypes, "ServerTypeId", "Title", server.ServerTypeId);
			return View(server);
		}

		// POST: Servers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ServerId,ServerTypeId,OsId,Ram,Cpu,Hard,Url,UserName,Password,Vpn,CustomerId")] Server server)
		{
			if (id != server.ServerId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(server);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ServerExists(server.ServerId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", server.CustomerId);
			ViewData["OsId"] = new SelectList(_context.Oses, "OsId", "Title", server.OsId);
			ViewData["ServerTypeId"] = new SelectList(_context.ServerTypes, "ServerTypeId", "Title", server.ServerTypeId);
			return View(server);
		}

		// GET: Servers/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var server = await _context.Servers
				.Include(s => s.Customer)
				.Include(s => s.Os)
				.Include(s => s.ServerType)
				.FirstOrDefaultAsync(m => m.ServerId == id);
			if (server == null)
			{
				return NotFound();
			}

			return View(server);
		}

		// POST: Servers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var server = await _context.Servers.FindAsync(id);
			_context.Servers.Remove(server);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ServerExists(int id)
		{
			return _context.Servers.Any(e => e.ServerId == id);
		}
	}
}
