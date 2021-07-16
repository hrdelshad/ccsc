using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Web.Areas.Admin.Controllers
{
    public class SqlVersionsController : AdminBaseController
    {
        private readonly CcscContext _context;

        public SqlVersionsController(CcscContext context)
        {
            _context = context;
        }

        // GET: SqlVersions
        public async Task<IActionResult> Index()
        {
            return View(await _context.SqlVersions.ToListAsync());
        }

        // GET: SqlVersions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sqlVersion = await _context.SqlVersions
                .FirstOrDefaultAsync(m => m.SqlVersionId == id);
            if (sqlVersion == null)
            {
                return NotFound();
            }

            return View(sqlVersion);
        }

        // GET: SqlVersions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SqlVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SqlVersionId,Title")] SqlVersion sqlVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sqlVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sqlVersion);
        }

        // GET: SqlVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sqlVersion = await _context.SqlVersions.FindAsync(id);
            if (sqlVersion == null)
            {
                return NotFound();
            }
            return View(sqlVersion);
        }

        // POST: SqlVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SqlVersionId,Title")] SqlVersion sqlVersion)
        {
            if (id != sqlVersion.SqlVersionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sqlVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SqlVersionExists(sqlVersion.SqlVersionId))
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
            return View(sqlVersion);
        }

        // GET: SqlVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sqlVersion = await _context.SqlVersions
                .FirstOrDefaultAsync(m => m.SqlVersionId == id);
            if (sqlVersion == null)
            {
                return NotFound();
            }

            return View(sqlVersion);
        }

        // POST: SqlVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sqlVersion = await _context.SqlVersions.FindAsync(id);
            _context.SqlVersions.Remove(sqlVersion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SqlVersionExists(int id)
        {
            return _context.SqlVersions.Any(e => e.SqlVersionId == id);
        }
    }
}
