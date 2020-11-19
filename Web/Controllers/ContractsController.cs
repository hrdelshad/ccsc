using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Controllers
{
    [Authorize]
    public class ContractsController : Controller
    {
        private readonly CcscContext _context;

        public ContractsController(CcscContext context)
        {
            _context = context;
        }

        // GET: Contracts1
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.Contracts.Include(c => c.ContractStatus).Include(c => c.Customer);
            return View(await ccscContext.ToListAsync());
        }

        // GET: Contracts1/Details/5
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

            return View(contract);
        }

        // GET: Contracts1/Create
        public IActionResult Create(int? id)
        {
            ViewData["ContractStatusId"] = new SelectList(_context.ContractStatuses, "ContractStatusId", "Title");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title");
            if (id != null)
            {
	            var customer = _context.Customers.Find(id);
	            var customerType = _context.CustomerTypes.Find(customer.CustomerTypeId);
	            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(c => c.CustomerId == id), "CustomerId", "Title");
	            ViewData["CustomerTitle"] = customer.Title;
	            ViewData["CustomerType"] = customerType.Title;
            }
            return View();
        }

        // POST: Contracts1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractId,Title,ContractNo,StartDate,Duration,Amount,UnLimited,ContractStatusId,CustomerId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractStatusId"] = new SelectList(_context.ContractStatuses, "ContractStatusId", "Title", contract.ContractStatusId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Title", contract.CustomerId);
            return View(contract);
        }

        // GET: Contracts1/Edit/5
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
            return View(contract);
        }

        // POST: Contracts1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractId,Title,ContractNo,StartDate,Duration,Amount,UnLimited,ContractStatusId,CustomerId")] Contract contract)
        {
            if (id != contract.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
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

        // GET: Contracts1/Delete/5
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

        // POST: Contracts1/Delete/5
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
