using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	//[Authorize]
	public class FaqsController : ControllerBase
	{
		private readonly CcscContext _context;

		public FaqsController(CcscContext context)
		{
			_context = context;
		}

		// GET: api/Faqs
		[HttpGet]
		//[ResponseCache(Duration = 60)]
		public async Task<ActionResult<IEnumerable<Faq>>> GetFaqs()
		{
			var result = await _context.Faqs
				//.Where(f => f.IsActive)
				.Include(v => v.SubSystems)
				.Include(v => v.UserTypes)
				.Include(v => v.Video)
				.ToListAsync();
			Request.HttpContext.Response.Headers.Add("x-New", "30");
			return result;
		}

		// GET: api/Faqs/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Faq>> GetFaq(int id)
		{
			var faq = await _context.Faqs.FindAsync(id);
			if (faq.VideoId != null)
			{
				var video = await _context.Videos.FindAsync(faq.VideoId);
				faq.Video = video;
			}
			if (faq == null)
			{
				return NotFound();
			}

			return faq;
		}

		// PUT: api/Faqs/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutFaq(int id, Faq faq)
		{
			var customer = _context.Customers.FirstOrDefault(c => c.UniversityId == faq.UniversityId);
			if (customer != null) faq.CustomerId = customer.CustomerId;
			if (id != faq.FaqId)
			{
				return BadRequest();
			}

			_context.Entry(faq).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FaqExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Faqs
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Faq>> PostFaq(Faq faq)
		{
			var customer = _context.Customers.FirstOrDefault(c => c.UniversityId == faq.UniversityId);
			if (customer != null) faq.CustomerId = customer.CustomerId;

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_context.Faqs.Add(faq);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetFaq", new { id = faq.FaqId }, faq);
		}

		// DELETE: api/Faqs/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFaq(int id)
		{
			var faq = await _context.Faqs.FindAsync(id);
			if (faq == null)
			{
				return NotFound();
			}

			_context.Faqs.Remove(faq);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool FaqExists(int id)
		{
			return _context.Faqs.Any(e => e.FaqId == id);
		}
	}
}
