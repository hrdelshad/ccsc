using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ccsc.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;

namespace ccsc.Web.Controllers
{
    public class CustomersController : Controller
    {
	    private ICustomerService _service;
        private readonly CcscContext _context;

        public CustomersController(ICustomerService service, CcscContext context)
        {
	        _service = service;
	        _context = context;
        }

        public IActionResult Version()
        {
	        
	        using (CcscContext db = new CcscContext())
	        {
		        var customerList = db.Customers.ToList();
		        foreach (Customer customer in customerList)
		        {
			        try
			        {
				        var version = _service.GetVersion(customer.Url);
				        customer.Version = version;
				        customer.VersionCheckDate = DateTime.Now;
				        db.SaveChanges();
			        }
			        finally
			        {
				        
			        }
		        }
	        }
	        return null;
        }


        // GET: Customers
        public async Task<IActionResult> Index()
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


		        }

	        await _context.SaveChangesAsync();

            return View(await ccscContext.ToListAsync());
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
            ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "TypeId", "Title");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Title,CustomerTypeId,Url,Version,VersionCheckDate,SMSUser,SMSPass,SMSCredit,MinSMSCredit,SMSCreditCheckDate,IsActiveSms,AfterXDay,SendSmsDate,UniversityId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "TypeId", "Title", customer.CustomerTypeId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "TypeId", "Title", customer.CustomerTypeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Title,CustomerTypeId,Url,Version,VersionCheckDate,SMSUser,SMSPass,SMSCredit,MinSMSCredit,SMSCreditCheckDate,IsActiveSms,AfterXDay,SendSmsDate,UniversityId")] Customer customer)
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
            ViewData["CustomerTypeId"] = new SelectList(_context.CustomerTypes, "TypeId", "Title", customer.CustomerTypeId);
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

    }
}
