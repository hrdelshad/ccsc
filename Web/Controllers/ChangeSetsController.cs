using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.Convertors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Products;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace ccsc.Web.Controllers
{
    public class ChangeSetsController : Controller
    {
        private readonly CcscContext _context;

        public ChangeSetsController(CcscContext context)
        {
            _context = context;
        }

        // GET: ChangeSets
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.ChangeSets.Include(c => c.User).OrderByDescending(u=>u.Date);
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
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ChangeSetId == id);
            if (changeSet == null)
            {
                return NotFound();
            }

            ChangeSetViewModel changeSetViewModel = new ChangeSetViewModel();
            changeSetViewModel.ChangeSetId = changeSet.ChangeSetId;
            changeSetViewModel.UserId = changeSet.UserId;
            changeSetViewModel.User = changeSet.User;
            changeSetViewModel.Comment = changeSet.Comment;
            changeSetViewModel.Description = changeSet.Description;
            changeSetViewModel.Version = changeSet.Version;
            changeSetViewModel.PersianDate = changeSet.Date.PersianDate();
            return View(changeSetViewModel);
        }

        // GET: ChangeSets/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "DisplayName");
            return View();
        }

        // POST: ChangeSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeSetId,UserId,Date,Comment,Description,Version")] ChangeSet changeSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changeSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "DisplayName", changeSet.UserId);
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "DisplayName", changeSet.UserId);
            return View(changeSet);
        }

        // POST: ChangeSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeSetId,UserId,Date,Comment,Description,Version")] ChangeSet changeSet)
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "DisplayName", changeSet.UserId);
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
                .Include(c => c.User)
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
