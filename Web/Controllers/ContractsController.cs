using System;
using System.Collections.Generic;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class ContractsController : Controller
	{
		private readonly CcscContext _context;
		private readonly IContractService _contractService;
		private readonly ISubSystemService _subSystemService;
		private ICourseService _courseService;

		public ContractsController(CcscContext context, IContractService contractService, ISubSystemService subSystemService, ICourseService courseService)
		{
			_context = context;
			_contractService = contractService;
			_subSystemService = subSystemService;
			_courseService = courseService;
		}

		// GET: Contracts
		public async Task<IActionResult> Index()
		{
			var ccscContext = _context.Contracts
				.Include(c => c.ContractStatus)
				.Include(c => c.Customer)
				.OrderBy(c=>c.StartDate.AddMonths(c.Duration));
			return View(await ccscContext.ToListAsync());
		}

		// GET: Contracts/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var contract = await _context.Contracts
				.Include(c => c.ContractStatus)
				.Include(c => c.Customer)
				.FirstOrDefaultAsync(m => m.ContractId == id);
			if (contract == null)
			{
				return NotFound();
			}
			ViewData["SelectedSubSystem"] = await _subSystemService.GetCurrentSubSystems("Contract", id.Value);

			return View(contract);
		}

		// GET: Contracts/Create
		public async Task<IActionResult> Create(int? id)
		{

			ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
			ViewData["ContractStatusId"] = new SelectList(_context.ContractStatuses, "ContractStatusId", "Title");
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title");
			if (id != null)
			{
				var customer = _context.Customers.Find(id);
				var customerType = _context.CustomerTypes.Find(customer.CustomerTypeId);
				ViewData["CustomerId"] = new SelectList(_context.Customers.Where(c => c.CustomerId == id), "CustomerId", "Title");
				ViewData["CustomerTitle"] = customer.Title;
				ViewData["CustomerType"] = customerType.Title;
				TempData["CId"] = customer.CustomerId;
			}
			return View();
		}

		// POST: Contracts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ContractId,Title,ContractNo,StartDate,Duration,Amount,UnLimited,ContractStatusId,CustomerId,Description")] Contract contract, List<int> selectedSubSystems)
		{
			if (ModelState.IsValid)
			{
				await _contractService.AddContract(contract, selectedSubSystems);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["ContractStatusId"] = new SelectList(_context.ContractStatuses, "ContractStatusId", "Title", contract.ContractStatusId);
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", contract.CustomerId);
			return View(contract);
		}

		// GET: Contracts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var contract = await _context.Contracts.FindAsync(id);
			if (contract == null)
			{
				return NotFound();
			}
			ViewData["ContractStatusId"] = new SelectList(_context.ContractStatuses, "ContractStatusId", "Title", contract.ContractStatusId);
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", contract.CustomerId);

			ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
			ViewData["SelectedSubSystem"] = await _subSystemService.GetCurrentSubSystems("Contract", id.Value);

			ViewData["Courses"] = await _courseService.GetCourses();
			ViewData["SelectedCourses"] = await _contractService.GetCoursesOfContract(id.Value);

			return View(contract);
		}

		// POST: Contracts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ContractId,Title,ContractNo,StartDate,Duration,Amount,UnLimited,ContractStatusId,CustomerId,Description")] Contract inputContract, List<int> selectedSubSystems)
		{
			if (id != inputContract.ContractId)
			{
				return NotFound();
			}

			var contract = _context.Contracts
				.Include(f => f.SubSystems)
				.Single(e => e.ContractId == id) ?? throw new ArgumentNullException("_context.Contracts\r\n\t\t        .Include(i => i.SubSystems)\r\n\t\t        .Where(i => i.ContractId == id).Single()");
			contract.Title = inputContract.Title;
			contract.ContractNo = inputContract.ContractNo;
			contract.StartDate = inputContract.StartDate;
			contract.Duration = inputContract.Duration;
			contract.Amount = inputContract.Amount;
			contract.UnLimited = inputContract.UnLimited;
			contract.ContractStatusId = inputContract.ContractStatusId;
			contract.CustomerId = inputContract.CustomerId;
			contract.Description = inputContract.Description;

			if (ModelState.IsValid)
			{
				try
				{
					
					
					await _contractService.RemoveContractRelatedAsync(contract);
					await _contractService.UpdateContractAsync(contract, selectedSubSystems);

					var customer = _context.Customers.Find(contract.CustomerId);
					if (contract.StartDate.AddMonths(contract.Duration) < DateTime.Now)
					{
						customer.HasUnSupportedContract = true;
						_context.Update(customer);
						await _context.SaveChangesAsync();
					}
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ContractExists(contract.ContractId))
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
			ViewData["ContractStatusId"] = new SelectList(_context.ContractStatuses, "ContractStatusId", "Title", contract.ContractStatusId);
			ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", contract.CustomerId);


			return View(contract);
		}

		// GET: Contracts/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var contract = await _context.Contracts
				.Include(c => c.ContractStatus)
				.Include(c => c.Customer)
				.FirstOrDefaultAsync(m => m.ContractId == id);
			if (contract == null)
			{
				return NotFound();
			}

			return View(contract);
		}

		// POST: Contracts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var contract = await _context.Contracts.FindAsync(id);
			_context.Contracts.Remove(contract);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ContractExists(int id)
		{
			return _context.Contracts.Any(e => e.ContractId == id);
		}
	}
}
