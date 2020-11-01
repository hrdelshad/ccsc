using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Contacts;

namespace ccsc.Web.Controllers
{
    public class SalutationsController : Controller
    {
        private readonly CcscContext _context;

        public SalutationsController(CcscContext context)
        {
            _context = context;
        }

        // GET: Salutations
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.Salutations.Include(s => s.Gender);
            return View(await ccscContext.ToListAsync());
        }

        // GET: Salutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salutation = await _context.Salutations
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(m => m.SalutationId == id);
            if (salutation == null)
            {
                return NotFound();
            }

            return View(salutation);
        }

        // GET: Salutations/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title");
            return View();
        }

        // POST: Salutations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalutationId,Title,GenderId")] Salutation salutation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salutation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title", salutation.GenderId);
            return View(salutation);
        }

        // GET: Salutations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salutation = await _context.Salutations.FindAsync(id);
            if (salutation == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title", salutation.GenderId);
            return View(salutation);
        }

        // POST: Salutations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalutationId,Title,GenderId")] Salutation salutation)
        {
            if (id != salutation.SalutationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salutation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalutationExists(salutation.SalutationId))
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
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "Title", salutation.GenderId);
            return View(salutation);
        }

        // GET: Salutations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salutation = await _context.Salutations
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(m => m.SalutationId == id);
            if (salutation == null)
            {
                return NotFound();
            }

            return View(salutation);
        }

        // POST: Salutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salutation = await _context.Salutations.FindAsync(id);
            _context.Salutations.Remove(salutation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalutationExists(int id)
        {
            return _context.Salutations.Any(e => e.SalutationId == id);
        }
    }
}
