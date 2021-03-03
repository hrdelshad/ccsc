using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Web.Controllers
{
	[Authorize]
    public class RequestStatusController : Controller
    {
        private readonly CcscContext _context;

        public RequestStatusController(CcscContext context)
        {
            _context = context;
        }

        // GET: RequestStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestStatuses.ToListAsync());
        }

        // GET: RequestStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestStatus = await _context.RequestStatuses
                .FirstOrDefaultAsync(m => m.RequestStatusId == id);
            if (requestStatus == null)
            {
                return NotFound();
            }

            return View(requestStatus);
        }

        // GET: RequestStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestStatusId,Title,IsActive")] RequestStatus requestStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestStatus);
        }

        // GET: RequestStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestStatus = await _context.RequestStatuses.FindAsync(id);
            if (requestStatus == null)
            {
                return NotFound();
            }
            return View(requestStatus);
        }

        // POST: RequestStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestStatusId,Title,IsActive")] RequestStatus requestStatus)
        {
            if (id != requestStatus.RequestStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestStatusExists(requestStatus.RequestStatusId))
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
            return View(requestStatus);
        }

        // GET: RequestStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestStatus = await _context.RequestStatuses
                .FirstOrDefaultAsync(m => m.RequestStatusId == id);
            if (requestStatus == null)
            {
                return NotFound();
            }

            return View(requestStatus);
        }

        // POST: RequestStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestStatus = await _context.RequestStatuses.FindAsync(id);
            _context.RequestStatuses.Remove(requestStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestStatusExists(int id)
        {
            return _context.RequestStatuses.Any(e => e.RequestStatusId == id);
        }
    }
}
