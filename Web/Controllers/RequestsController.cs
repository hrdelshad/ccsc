using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Web.Controllers
{
	[Authorize]
    public class RequestsController : Controller
    {
	    private ICustomerService _customerService;
        private readonly CcscContext _context;

        public RequestsController(CcscContext context, ICustomerService customerService)
        {
	        _context = context;
	        _customerService = customerService;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.Requests.Include(r => r.Contact).Include(r => r.Customer).Include(r => r.RequestChanel).Include(r => r.RequestStatus).Include(r => r.RequestType).Include(r => r.SubSystem);
            return View(await ccscContext.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Contact)
                .Include(r => r.Customer)
                .Include(r => r.RequestChanel)
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .Include(r => r.SubSystem)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
	        var customers = _customerService.GetCustomerListItems();
            ViewData["CustomerId"] = _customerService.GetCustomerListItems();
            ViewData["ContactId"] = _customerService.GetContactOfCustomerListItems(int.Parse(customers.First().Value),true);
            //ViewData["ContactId"] = _customerService.GetContactOfCustomerListItems(int.Parse(customers.First().Value));
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChannels, "RequestChannelId", "Title");
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title");
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title");
            ViewData["SubSystemId"] = new SelectList(_context.SubSystems, "SubSystemId", "Title");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,CustomerId,ContactId,RequestTime,RequestChanelId,RequestTypeId,SubSystemId,RequestStatusId,Title,Text")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email", request.ContactId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", request.CustomerId);
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChannels, "RequestChannelId", "Title", request.RequestChanelId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title", request.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title", request.RequestTypeId);
            ViewData["SubSystemId"] = new SelectList(_context.SubSystems, "SubSystemId", "Title", request.SubSystemId);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email", request.ContactId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", request.CustomerId);
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChannels, "RequestChannelId", "Title", request.RequestChanelId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title", request.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title", request.RequestTypeId);
            ViewData["SubSystemId"] = new SelectList(_context.SubSystems, "SubSystemId", "Title", request.SubSystemId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,CustomerId,ContactId,RequestTime,RequestChanelId,RequestTypeId,SubSystemId,RequestStatusId,Title,Text")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestId))
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
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email", request.ContactId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", request.CustomerId);
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChannels, "RequestChannelId", "Title", request.RequestChanelId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title", request.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title", request.RequestTypeId);
            ViewData["SubSystemId"] = new SelectList(_context.SubSystems, "SubSystemId", "Title", request.SubSystemId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Contact)
                .Include(r => r.Customer)
                .Include(r => r.RequestChanel)
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .Include(r => r.SubSystem)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestId == id);
        }

       
    }
}
