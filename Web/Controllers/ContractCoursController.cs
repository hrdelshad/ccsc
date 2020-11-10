using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Controllers
{
	[Authorize]
    public class ContractCoursController : Controller
    {
        private readonly CcscContext _context;

        public ContractCoursController(CcscContext context)
        {
            _context = context;
        }

        // GET: ContractCours
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.ContractCourses.Include(c => c.Contract).Include(c => c.Course);
            return View(await ccscContext.ToListAsync());
        }

        // GET: ContractCours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractCours = await _context.ContractCourses
                .Include(c => c.Contract)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.ContractCoursId == id);
            if (contractCours == null)
            {
                return NotFound();
            }

            return View(contractCours);
        }

        // GET: ContractCours/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title");
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title");
            return View();
        }

        // POST: ContractCours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractCoursId,ContractId,CourseId")] ContractCours contractCours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractCours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title", contractCours.ContractId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", contractCours.CourseId);
            return View(contractCours);
        }

        // GET: ContractCours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractCours = await _context.ContractCourses.FindAsync(id);
            if (contractCours == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title", contractCours.ContractId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", contractCours.CourseId);
            return View(contractCours);
        }

        // POST: ContractCours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractCoursId,ContractId,CourseId")] ContractCours contractCours)
        {
            if (id != contractCours.ContractCoursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractCours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractCoursExists(contractCours.ContractCoursId))
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
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title", contractCours.ContractId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", contractCours.CourseId);
            return View(contractCours);
        }

        // GET: ContractCours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractCours = await _context.ContractCourses
                .Include(c => c.Contract)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.ContractCoursId == id);
            if (contractCours == null)
            {
                return NotFound();
            }

            return View(contractCours);
        }

        // POST: ContractCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractCours = await _context.ContractCourses.FindAsync(id);
            _context.ContractCourses.Remove(contractCours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractCoursExists(int id)
        {
            return _context.ContractCourses.Any(e => e.ContractCoursId == id);
        }
    }
}
