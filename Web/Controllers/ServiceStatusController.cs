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
    public class ServiceStatusController : Controller
    {
        private readonly CcscContext _context;

        public ServiceStatusController(CcscContext context)
        {
            _context = context;
        }

        // GET: ServiceStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceStatuses.ToListAsync());
        }

        // GET: ServiceStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceStatus = await _context.ServiceStatuses
                .FirstOrDefaultAsync(m => m.ServiceStatusId == id);
            if (serviceStatus == null)
            {
                return NotFound();
            }

            return View(serviceStatus);
        }

        // GET: ServiceStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceStatusId,title,IsOk")] ServiceStatus serviceStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceStatus);
        }

        // GET: ServiceStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceStatus = await _context.ServiceStatuses.FindAsync(id);
            if (serviceStatus == null)
            {
                return NotFound();
            }
            return View(serviceStatus);
        }

        // POST: ServiceStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceStatusId,title,IsOk")] ServiceStatus serviceStatus)
        {
            if (id != serviceStatus.ServiceStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceStatusExists(serviceStatus.ServiceStatusId))
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
            return View(serviceStatus);
        }

        // GET: ServiceStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceStatus = await _context.ServiceStatuses
                .FirstOrDefaultAsync(m => m.ServiceStatusId == id);
            if (serviceStatus == null)
            {
                return NotFound();
            }

            return View(serviceStatus);
        }

        // POST: ServiceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceStatus = await _context.ServiceStatuses.FindAsync(id);
            _context.ServiceStatuses.Remove(serviceStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceStatusExists(int id)
        {
            return _context.ServiceStatuses.Any(e => e.ServiceStatusId == id);
        }
    }
}
