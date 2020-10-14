using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Services;

namespace ccsc.Web.Controllers
{
    public class DutiesController : Controller
    {
        private readonly CcscContext _context;

        public DutiesController(CcscContext context)
        {
            _context = context;
        }

        // GET: Duties
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.Duties.Include(d => d.DutyStatus).Include(d => d.Request).Include(d => d.Service);
            return View(await ccscContext.ToListAsync());
        }

        // GET: Duties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty = await _context.Duties
                .Include(d => d.DutyStatus)
                .Include(d => d.Request)
                .Include(d => d.Service)
                .FirstOrDefaultAsync(m => m.DutyId == id);
            if (duty == null)
            {
                return NotFound();
            }

            return View(duty);
        }

        // GET: Duties/Create
        public IActionResult Create()
        {
            ViewData["DutyStatusId"] = new SelectList(_context.DutyStatuses, "DutyStatusId", "Title");
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "Text");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "text");
            return View();
        }

        // POST: Duties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DutyId,Title,ServiceId,RequestId,DutyDate,DuoDate,DoneDate,DutyStatusId")] Duty duty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DutyStatusId"] = new SelectList(_context.DutyStatuses, "DutyStatusId", "Title", duty.DutyStatusId);
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "Text", duty.RequestId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "text", duty.ServiceId);
            return View(duty);
        }

        // GET: Duties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty = await _context.Duties.FindAsync(id);
            if (duty == null)
            {
                return NotFound();
            }
            ViewData["DutyStatusId"] = new SelectList(_context.DutyStatuses, "DutyStatusId", "Title", duty.DutyStatusId);
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "Text", duty.RequestId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "text", duty.ServiceId);
            return View(duty);
        }

        // POST: Duties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DutyId,Title,ServiceId,RequestId,DutyDate,DuoDate,DoneDate,DutyStatusId")] Duty duty)
        {
            if (id != duty.DutyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DutyExists(duty.DutyId))
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
            ViewData["DutyStatusId"] = new SelectList(_context.DutyStatuses, "DutyStatusId", "Title", duty.DutyStatusId);
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "Text", duty.RequestId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "text", duty.ServiceId);
            return View(duty);
        }

        // GET: Duties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty = await _context.Duties
                .Include(d => d.DutyStatus)
                .Include(d => d.Request)
                .Include(d => d.Service)
                .FirstOrDefaultAsync(m => m.DutyId == id);
            if (duty == null)
            {
                return NotFound();
            }

            return View(duty);
        }

        // POST: Duties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duty = await _context.Duties.FindAsync(id);
            _context.Duties.Remove(duty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DutyExists(int id)
        {
            return _context.Duties.Any(e => e.DutyId == id);
        }
    }
}
