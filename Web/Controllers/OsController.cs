using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Web.Controllers
{
	[Authorize]
    public class OsController : Controller
    {
        private readonly CcscContext _context;

        public OsController(CcscContext context)
        {
            _context = context;
        }

        // GET: Os
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oses.ToListAsync());
        }

        // GET: Os/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var os = await _context.Oses
                .FirstOrDefaultAsync(m => m.OsId == id);
            if (os == null)
            {
                return NotFound();
            }

            return View(os);
        }

        // GET: Os/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Os/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OsId,Title")] Os os)
        {
            if (ModelState.IsValid)
            {
                _context.Add(os);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(os);
        }

        // GET: Os/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var os = await _context.Oses.FindAsync(id);
            if (os == null)
            {
                return NotFound();
            }
            return View(os);
        }

        // POST: Os/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OsId,Title")] Os os)
        {
            if (id != os.OsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(os);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsExists(os.OsId))
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
            return View(os);
        }

        // GET: Os/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var os = await _context.Oses
                .FirstOrDefaultAsync(m => m.OsId == id);
            if (os == null)
            {
                return NotFound();
            }

            return View(os);
        }

        // POST: Os/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var os = await _context.Oses.FindAsync(id);
            _context.Oses.Remove(os);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsExists(int id)
        {
            return _context.Oses.Any(e => e.OsId == id);
        }
    }
}
