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
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class FaqsController : Controller
	{
		private readonly CcscContext _context;
		private readonly IFaqService _faqService;
		private readonly ISubSystemService _subSystemService;
		private readonly IUserTypeService _userTypeService;

		public FaqsController(CcscContext context, IFaqService faqService, ISubSystemService subSystemService, IUserTypeService userTypeService)
		{
			_context = context;
			_faqService = faqService;
			_subSystemService = subSystemService;
			_userTypeService = userTypeService;
		}

		// GET: Faqs
		public async Task<IActionResult> Index()
		{
			var ccscContext = _context.Faqs
				.Include(f => f.Customer)
				.Include(f => f.Video);
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
				.Include(f => f.Customer)
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
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title");
			ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Description");
			ViewData["SubSystem"] = _subSystemService.GetSubSystems();
			ViewData["UserType"] = _userTypeService.GetUserTypes();
			return View();
		}

		// POST: Faqs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("FaqId,Question,Answer,IsActive,CustomerId,VideoId")] Faq faq, List<int> selectedSubSystems, List<int> selectedUserTypes)
		{
			if (ModelState.IsValid)
			{
				await _faqService.AddFaqAsync(faq, selectedSubSystems, selectedUserTypes);
				return RedirectToAction(nameof(Index));
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", faq.CustomerId);
			ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title", faq.VideoId);
			
		
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
			if (faq.CustomerId != null)
			{
				var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == faq.CustomerId);
				faq.UniversityId = customer.UniversityId;
			}

			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", faq.CustomerId);
			ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title", faq.VideoId);

			ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
			ViewData["UserType"] = await _userTypeService.GetUserTypes();
			ViewData["SelectedSubSystem"] = await _subSystemService.GetSubSystemsOfFaq(id.Value);
			ViewData["SelectedUserType"] = await _userTypeService.GetUserTypesForFaq(id.Value);
			return View(faq);
		}

		// POST: Faqs/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("FaqId,Question,Answer,IsActive,CustomerId,VideoId")] Faq faq, List<int> selectedSubSystems, List<int> selectedUserTypes)
		{

			var updatedInput = _context.Faqs
				.Include(f => f.SubSystems)
				.Include(f => f.UserTypes)
				.Single(f => f.FaqId == id) ?? throw new ArgumentNullException("_context.Faqs\r\n\t\t        .Include(i => i.SubSystems)\r\n\t\t        .Include(i => i.UserTypes)\r\n\t\t        .Where(i => i.FqqId == id).Single()");

			updatedInput.Question = faq.Question;
			updatedInput.ModifiedOn = DateTime.Now;
			updatedInput.Answer = faq.Answer;
			updatedInput.IsActive = faq.IsActive;
			updatedInput.Publish = faq.Publish;
			updatedInput.CustomerId = faq.CustomerId;
			updatedInput.Version = faq.Version;
			updatedInput.VideoId = faq.VideoId;

			if (id != faq.FaqId)
			{
				return NotFound();
			}

			if (faq.CustomerId != null)
			{
				var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == faq.CustomerId);
				faq.UniversityId = customer.UniversityId;
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _faqService.RemoveFaqRelatedAsync(updatedInput);

					await _faqService.UpdateFaqAsync(updatedInput, selectedSubSystems, selectedUserTypes);

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
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", faq.CustomerId);
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
				.Include(f => f.Customer)
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
