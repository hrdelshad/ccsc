using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Web.Areas.Admin.Controllers
{
	public class DutyStatusController : AdminBaseController
    {
        private readonly CcscContext _context;

        public DutyStatusController(CcscContext context)
        {
            _context = context;
        }

        // GET: DutyStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.DutyStatuses.ToListAsync());
        }

        // GET: DutyStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutyStatus = await _context.DutyStatuses
                .FirstOrDefaultAsync(m => m.DutyStatusId == id);
            if (dutyStatus == null)
            {
                return NotFound();
            }

            return View(dutyStatus);
        }

        // GET: DutyStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DutyStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DutyStatusId,Title,IsOpen")] DutyStatus dutyStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dutyStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dutyStatus);
        }

        // GET: DutyStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutyStatus = await _context.DutyStatuses.FindAsync(id);
            if (dutyStatus == null)
            {
                return NotFound();
            }
            return View(dutyStatus);
        }

        // POST: DutyStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DutyStatusId,Title,IsOpen")] DutyStatus dutyStatus)
        {
            if (id != dutyStatus.DutyStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dutyStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DutyStatusExists(dutyStatus.DutyStatusId))
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
            return View(dutyStatus);
        }

        // GET: DutyStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutyStatus = await _context.DutyStatuses
                .FirstOrDefaultAsync(m => m.DutyStatusId == id);
            if (dutyStatus == null)
            {
                return NotFound();
            }

            return View(dutyStatus);
        }

        // POST: DutyStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dutyStatus = await _context.DutyStatuses.FindAsync(id);
            _context.DutyStatuses.Remove(dutyStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DutyStatusExists(int id)
        {
            return _context.DutyStatuses.Any(e => e.DutyStatusId == id);
        }
    }
}
