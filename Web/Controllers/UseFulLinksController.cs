using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Common;

namespace ccsc.Web.Controllers
{
    public class UseFulLinksController : Controller
    {
        private readonly CcscContext _context;

        public UseFulLinksController(CcscContext context)
        {
            _context = context;
        }

        // GET: UseFulLinks
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.UseFulLinks.Include(u => u.Owner);
            return View(await ccscContext.ToListAsync());
        }

        // GET: UseFulLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useFulLink = await _context.UseFulLinks
                .Include(u => u.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useFulLink == null)
            {
                return NotFound();
            }

            return View(useFulLink);
        }

        // GET: UseFulLinks/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "DisplayName");
            return View();
        }

        // POST: UseFulLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Url,Description,OwnerId")] UseFulLink useFulLink)
        {
            if (ModelState.IsValid)
            {
	            if (useFulLink.Url.StartsWith("http://") || useFulLink.Url.StartsWith("http://"))
	            {
		            useFulLink.Url = useFulLink.Url;
	            }
	            else
	            {
		            useFulLink.Url = "http://" + useFulLink.Url;
                }
                _context.Add(useFulLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "DisplayName", useFulLink.OwnerId);
            return View(useFulLink);
        }

        // GET: UseFulLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useFulLink = await _context.UseFulLinks.FindAsync(id);
            if (useFulLink == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "DisplayName", useFulLink.OwnerId);
            return View(useFulLink);
        }

        // POST: UseFulLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Url,Description,OwnerId")] UseFulLink useFulLink)
        {
            if (id != useFulLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
	                if (useFulLink.Url.StartsWith("http://") || useFulLink.Url.StartsWith("http://"))
	                {
		                useFulLink.Url = useFulLink.Url;
	                }
	                else
	                {
		                useFulLink.Url = "http://" + useFulLink.Url;
	                }
                    _context.Update(useFulLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UseFulLinkExists(useFulLink.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "DisplayName", useFulLink.OwnerId);
            return View(useFulLink);
        }

        // GET: UseFulLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useFulLink = await _context.UseFulLinks
                .Include(u => u.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useFulLink == null)
            {
                return NotFound();
            }

            return View(useFulLink);
        }

        // POST: UseFulLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var useFulLink = await _context.UseFulLinks.FindAsync(id);
            _context.UseFulLinks.Remove(useFulLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UseFulLinkExists(int id)
        {
            return _context.UseFulLinks.Any(e => e.Id == id);
        }
    }
}
