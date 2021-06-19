using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class CustomersController : Controller
	{
		private readonly ISmsService _smsService;
		private readonly ICustomerService _service;
		private readonly CcscContext _context;
		private IConfigService _config;

		public CustomersController(ISmsService smsService, ICustomerService service, CcscContext context, IConfigService config)
		{
			_smsService = smsService;
			_service = service;
			_context = context;
			_config = config;
		}

		// GET: Customers
		public async Task<IActionResult> Index(string searchString)
		{
			TempData["MinVersion"] = _config.GetConfigValue("MinVersion");
			TempData["MinVersionDescription"] = _config.GetConfigDescription("MinVersion");
			 
			var customers = _service.getCustomers()
				.OrderBy(c => c.Title.Trim());

			if (!String.IsNullOrEmpty(searchString))
			{
				customers = _service.getCustomers()
					.Where(c => c.Title.Contains(searchString))
					.OrderBy(c => c.Title.Trim());
			}

			return View (customers);
		}

		[HttpPost]
		public string Index(string searchString, bool notUsed)
		{
			return "From [HttpPost]Index: filter on " + searchString;
		}

		// GET: Customers/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.Include(c => c.CustomerType)
				.Include(c => c.Servers).ThenInclude(s => s.ServerType)
				.Include(c => c.Contracts).ThenInclude(c=>c.SubSystems)
				.Include(c => c.Contracts).ThenInclude(c => c.ContractStatus)
				.Include(c => c.Contacts)
				.Include(c => c.Services)
				.Include(c => c.Requests).ThenInclude(r => r.RequestType)
				.FirstOrDefaultAsync(m => m.CustomerId == id);
			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		// GET: Customers/Create
		public IActionResult Create()
		{
            ViewData["CustomerStatusId"] = new SelectList(_context.CustomerStatuses, "CustomerStatusId", "Title");
			ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "CustomerTypeId", "Title");
			return View();
		}

		// POST: Customers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CustomerId,Title,Url,Version,VersionCheckDate,SmsUser,SmsPass,SmsCredit,MinSmsCredit,SmsCreditCheckDate,IsActiveSms,AfterXDay,SendSmsDate,UniversityId,HasUnSupportedContract,CustomerStatusId,CustomerTypeId,UniversityCode,Description")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				_context.Add(customer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CustomerStatusId"] = new SelectList(_context.CustomerStatuses, "CustomerStatusId", "Title", customer.CustomerStatusId);
			ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "CustomerTypeId", "Title", customer.CustomerTypeId);
			return View(customer);
		}

		// GET: Customers/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.Include(c => c.CustomerType)
				.Include(c => c.Servers).ThenInclude(s => s.ServerType)
				.Include(c => c.Contracts).ThenInclude(c => c.SubSystems)
				.Include(c => c.Contracts).ThenInclude(c => c.ContractStatus)
				.Include(c => c.Contacts)
				.Include(c => c.Services)
				.Include(c => c.Requests).ThenInclude(r => r.RequestType)
				.FirstOrDefaultAsync(m => m.CustomerId == id);
			if (customer == null)
			{
				return NotFound();
			}
			ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "CustomerTypeId", "Title", customer.CustomerTypeId);
			ViewData["CustomerStatusId"] = new SelectList(_context.CustomerStatuses, "CustomerStatusId", "Title", customer.CustomerStatusId);
			return View(customer);
		}

		// POST: Customers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Title,Url,Version,VersionCheckDate,SmsUser,SmsPass,SmsCredit,MinSmsCredit,SmsCreditCheckDate,IsActiveSms,AfterXDay,SendSmsDate,UniversityId,HasUnSupportedContract,CustomerStatusId,CustomerTypeId,UniversityCode,Description")] Customer customer)
		{
			if (id != customer.CustomerId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(customer);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_service.CustomerExists(customer.CustomerId))
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
			ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "CustomerTypeId", "Title", customer.CustomerTypeId);
			ViewData["CustomerStatuses"] = new SelectList(_context.CustomerStatuses, "CustomerStatusId", "Title", customer.CustomerStatusId);
			return View(customer);
		}

		// GET: Customers/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.Include(c => c.CustomerStatus)
				.Include(c => c.CustomerType)
				.FirstOrDefaultAsync(m => m.CustomerId == id);
			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		// POST: Customers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> Versions()
		{

			var ccscContext = _context.Customers.Include(c => c.CustomerType);
			foreach (Customer customer in ccscContext)
				try
				{
					var version = _service.GetVersion(customer.Url);

					customer.Version = version;
					customer.VersionCheckDate = DateTime.Now;
					_context.Update(customer);

				}
				catch
				{
					// ignored
				}

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}



		public async Task<IActionResult> Version(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}


			var customer = await _context.Customers.FindAsync(id);
			try
			{
				var version = _service.GetVersion(customer.Url);

				customer.Version = version;
				customer.VersionCheckDate = DateTime.Now;
				_context.Update(customer);

			}
			catch (Exception)
			{
				// ignored
			}

			await _context.SaveChangesAsync();
			var url = "../Details/" + id.Value.ToString();
			return Redirect(url);
		}

		public async Task<IActionResult> SmsCredit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}


			var customer = await _context.Customers.FindAsync(id);
			try
			{
				var smsCredit = _smsService.GetSMSCredit(customer.SmsUser, customer.SmsPass);

				customer.SmsCredit = smsCredit;
				customer.SmsCreditCheckDate = DateTime.Now;
				_context.Update(customer);

			}
			catch (Exception)
			{
				// ignored
			}

			await _context.SaveChangesAsync();
			var url = "../Details/" + id.Value.ToString();
			return Redirect(url);
		}


		public async Task<IActionResult> SmsCredits()
		{

			var ccscContext = _context.Customers
				.Include(c => c.CustomerType)
				.Where(c=>c.IsActiveSms);
			foreach (Customer customer in ccscContext)
				try
				{
					var smsCredit = _smsService.GetSMSCredit(customer.SmsUser, customer.SmsPass);

					customer.SmsCredit = smsCredit;
					customer.SmsCreditCheckDate = DateTime.Now;
					_context.Update(customer);

				}
				catch
				{
					// ignored
				}

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> SetSupportStatus()
		{

			var ccscContext = _context.Customers;
			foreach (Customer customer in ccscContext)
				try
				{
					var supportStatus = _service.HasUnSupportedContract(customer.CustomerId);

					customer.HasUnSupportedContract = supportStatus;
					_context.Update(customer);

				}
				catch
				{
					// ignored
				}

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> GetContactsOfCustomer(int id)
		{
			var contacts = _service.GetContactOfCustomerListItems(id, true);
			var res = Json(contacts);
			return res;
		}
	}
}
