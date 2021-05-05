using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Tutorials;

namespace ccsc.Web.Controllers
{
    public class FaqsController : Controller
    {
        private readonly CcscContext _context;
        private readonly IFaqService _faqService;

        public FaqsController(CcscContext context, IFaqService faqService)
        {
	        _context = context;
	        _faqService = faqService;
        }

        // GET: Faqs
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.Faqs.Include(f => f.Video);
            return View(await ccscContext.ToListAsync());
        }

        // GET: Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs
                .Include(f => f.Video)
                .FirstOrDefaultAsync(m => m.FaqId == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // GET: Faqs/Create
        public IActionResult Create()
        {
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title");
            ViewData["SubSystem"] = _faqService.GetSubSystems();
            ViewData["UserType"] = _faqService.GetUserTypes();
            return View();
        }

        // POST: Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaqId,Question,Answer,IsActive,VideoId")] Faq faq, List<int> selectedSubSystems, List<int> selectedUserTypes)
        {
            if (ModelState.IsValid)
            {
                _faqService.AddFaq(faq, selectedSubSystems, selectedUserTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description", faq.VideoId);
            return View(faq);
        }

        // GET: Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description", faq.VideoId);
            return View(faq);
        }

        // POST: Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaqId,Question,Answer,IsActive,VideoId")] Faq faq)
        {
            if (id != faq.FaqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqExists(faq.FaqId))
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
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description", faq.VideoId);
            return View(faq);
        }

        // GET: Faqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs
                .Include(f => f.Video)
                .FirstOrDefaultAsync(m => m.FaqId == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // POST: Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = await _context.Faqs.FindAsync(id);
            _context.Faqs.Remove(faq);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqExists(int id)
        {
            return _context.Faqs.Any(e => e.FaqId == id);
        }
    }
}
