using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Courses;

namespace ccsc.Web.Controllers
{
    public class CourseLevelsController : Controller
    {
        private readonly CcscContext _context;

        public CourseLevelsController(CcscContext context)
        {
            _context = context;
        }

        // GET: CourseLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseLevels.ToListAsync());
        }

        // GET: CourseLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLevel = await _context.CourseLevels
                .FirstOrDefaultAsync(m => m.CourseLevelId == id);
            if (courseLevel == null)
            {
                return NotFound();
            }

            return View(courseLevel);
        }

        // GET: CourseLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseLevelId,Title,CourseCode")] CourseLevel courseLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseLevel);
        }

        // GET: CourseLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLevel = await _context.CourseLevels.FindAsync(id);
            if (courseLevel == null)
            {
                return NotFound();
            }
            return View(courseLevel);
        }

        // POST: CourseLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseLevelId,Title,CourseCode")] CourseLevel courseLevel)
        {
            if (id != courseLevel.CourseLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseLevelExists(courseLevel.CourseLevelId))
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
            return View(courseLevel);
        }

        // GET: CourseLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLevel = await _context.CourseLevels
                .FirstOrDefaultAsync(m => m.CourseLevelId == id);
            if (courseLevel == null)
            {
                return NotFound();
            }

            return View(courseLevel);
        }

        // POST: CourseLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseLevel = await _context.CourseLevels.FindAsync(id);
            _context.CourseLevels.Remove(courseLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseLevelExists(int id)
        {
            return _context.CourseLevels.Any(e => e.CourseLevelId == id);
        }
    }
}
