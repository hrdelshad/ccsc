using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Products;

namespace ccsc.Web.Controllers
{
    public class ChangeSets_Controller : Controller
    {
        private readonly CcscContext _context;

        public ChangeSets_Controller(CcscContext context)
        {
            _context = context;
        }

        // GET: ChangeSets
        public async Task<IActionResult> Index(string searchString)
        {
            var ccscContext = _context.ChangeSets
	            .Include(c => c.ChangeType)
	            .Include(c => c.Product)
	            .Include(c => c.AppUser)
	            .Include(c => c.Video)
	            .OrderByDescending(c=>c.Date);
            
            if (!String.IsNullOrEmpty(searchString))
            {
	            ccscContext = (IOrderedQueryable<ChangeSet>) ccscContext.Where(c =>
		            c.Title.Contains(searchString) ||
		            c.Comment.Contains(searchString) ||
		            c.Description.Contains(searchString));
	           
            }
            ViewData["Count"] = ccscContext.Count();
            return View(await ccscContext.ToListAsync());
        }

        // GET: ChangeSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _context.ChangeSets
                .Include(c => c.ChangeType)
                .Include(c => c.Product)
                .Include(c => c.AppUser)
                .Include(c => c.Video)
                .FirstOrDefaultAsync(m => m.ChangeSetId == id);
            if (changeSet == null)
            {
                return NotFound();
            }

            return View(changeSet);
        }

        // GET: ChangeSets/Create
        public IActionResult Create()
        {
            ViewData["ChangeTypeId"] = new SelectList(_context.Set<ChangeType>(), "ChangeTypeId", "Description");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title");
            ViewData["UserId"] = new SelectList(_context.AppUsers, "UserId", "DisplayName");
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description");
            return View();
        }

        // POST: ChangeSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeSetId,UserId,Date,Comment,Title,Description,Version,VideoId,ProductId,ChangeTypeId")] ChangeSet changeSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changeSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChangeTypeId"] = new SelectList(_context.Set<ChangeType>(), "ChangeTypeId", "Description", changeSet.ChangeTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", changeSet.ProductId);
            ViewData["UserId"] = new SelectList(_context.AppUsers, "UserId", "DisplayName", changeSet.AppUserId);
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description", changeSet.VideoId);
            return View(changeSet);
        }

        // GET: ChangeSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _context.ChangeSets.FindAsync(id);
            if (changeSet == null)
            {
                return NotFound();
            }
            ViewData["ChangeTypeId"] = new SelectList(_context.Set<ChangeType>(), "ChangeTypeId", "Description", changeSet.ChangeTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", changeSet.ProductId);
            ViewData["UserId"] = new SelectList(_context.AppUsers, "UserId", "DisplayName", changeSet.AppUserId);
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description", changeSet.VideoId);
            return View(changeSet);
        }

        // POST: ChangeSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeSetId,UserId,Date,Comment,Title,Description,Version,VideoId,ProductId,ChangeTypeId")] ChangeSet changeSet)
        {
            if (id != changeSet.ChangeSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(changeSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeSetExists(changeSet.ChangeSetId))
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
            ViewData["ChangeTypeId"] = new SelectList(_context.Set<ChangeType>(), "ChangeTypeId", "Description", changeSet.ChangeTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", changeSet.ProductId);
            ViewData["UserId"] = new SelectList(_context.AppUsers, "UserId", "DisplayName", changeSet.AppUserId);
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description", changeSet.VideoId);
            return View(changeSet);
        }

        // GET: ChangeSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _context.ChangeSets
                .Include(c => c.ChangeType)
                .Include(c => c.Product)
                .Include(c => c.AppUser)
                .Include(c => c.Video)
                .FirstOrDefaultAsync(m => m.ChangeSetId == id);
            if (changeSet == null)
            {
                return NotFound();
            }

            return View(changeSet);
        }

        // POST: ChangeSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var changeSet = await _context.ChangeSets.FindAsync(id);
            _context.ChangeSets.Remove(changeSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangeSetExists(int id)
        {
            return _context.ChangeSets.Any(e => e.ChangeSetId == id);
        }
    }
}
