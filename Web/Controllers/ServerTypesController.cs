using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;

namespace ccsc.Web.Controllers
{
    public class ServerTypesController : Controller
    {
        private readonly CcscContext _context;

        public ServerTypesController(CcscContext context)
        {
            _context = context;
        }

        // GET: ServerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServerTypes.ToListAsync());
        }

        // GET: ServerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serverType = await _context.ServerTypes
                .FirstOrDefaultAsync(m => m.ServerTypeId == id);
            if (serverType == null)
            {
                return NotFound();
            }

            return View(serverType);
        }

        // GET: ServerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServerTypeId,Title")] ServerType serverType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serverType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serverType);
        }

        // GET: ServerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serverType = await _context.ServerTypes.FindAsync(id);
            if (serverType == null)
            {
                return NotFound();
            }
            return View(serverType);
        }

        // POST: ServerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServerTypeId,Title")] ServerType serverType)
        {
            if (id != serverType.ServerTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serverType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerTypeExists(serverType.ServerTypeId))
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
            return View(serverType);
        }

        // GET: ServerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serverType = await _context.ServerTypes
                .FirstOrDefaultAsync(m => m.ServerTypeId == id);
            if (serverType == null)
            {
                return NotFound();
            }

            return View(serverType);
        }

        // POST: ServerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serverType = await _context.ServerTypes.FindAsync(id);
            _context.ServerTypes.Remove(serverType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServerTypeExists(int id)
        {
            return _context.ServerTypes.Any(e => e.ServerTypeId == id);
        }
    }
}
