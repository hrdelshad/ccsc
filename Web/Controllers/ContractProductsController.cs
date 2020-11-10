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
    public class ContractProductsController : Controller
    {
        private readonly CcscContext _context;

        public ContractProductsController(CcscContext context)
        {
            _context = context;
        }

        // GET: ContractProducts
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.ContractProducts.Include(c => c.Contract).Include(c => c.Product);
            return View(await ccscContext.ToListAsync());
        }

        // GET: ContractProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractProduct = await _context.ContractProducts
                .Include(c => c.Contract)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.ContractProductId == id);
            if (contractProduct == null)
            {
                return NotFound();
            }

            return View(contractProduct);
        }

        // GET: ContractProducts/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title");
            return View();
        }

        // POST: ContractProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractProductId,ContractId,ProductId")] ContractProduct contractProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title", contractProduct.ContractId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", contractProduct.ProductId);
            return View(contractProduct);
        }

        // GET: ContractProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractProduct = await _context.ContractProducts.FindAsync(id);
            if (contractProduct == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title", contractProduct.ContractId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", contractProduct.ProductId);
            return View(contractProduct);
        }

        // POST: ContractProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractProductId,ContractId,ProductId")] ContractProduct contractProduct)
        {
            if (id != contractProduct.ContractProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractProductExists(contractProduct.ContractProductId))
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
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Title", contractProduct.ContractId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", contractProduct.ProductId);
            return View(contractProduct);
        }

        // GET: ContractProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractProduct = await _context.ContractProducts
                .Include(c => c.Contract)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.ContractProductId == id);
            if (contractProduct == null)
            {
                return NotFound();
            }

            return View(contractProduct);
        }

        // POST: ContractProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractProduct = await _context.ContractProducts.FindAsync(id);
            _context.ContractProducts.Remove(contractProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractProductExists(int id)
        {
            return _context.ContractProducts.Any(e => e.ContractProductId == id);
        }
    }
}
