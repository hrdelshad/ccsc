using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Requests;

namespace ccsc.Web.Controllers
{
    public class RequestChanelsController : Controller
    {
        private readonly CcscContext _context;

        public RequestChanelsController(CcscContext context)
        {
            _context = context;
        }

        // GET: RequestChanels
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestChanels.ToListAsync());
        }

        // GET: RequestChanels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestChanel = await _context.RequestChanels
                .FirstOrDefaultAsync(m => m.RequestChanelId == id);
            if (requestChanel == null)
            {
                return NotFound();
            }

            return View(requestChanel);
        }

        // GET: RequestChanels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestChanels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestChanelId,Title")] RequestChanel requestChanel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestChanel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestChanel);
        }

        // GET: RequestChanels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestChanel = await _context.RequestChanels.FindAsync(id);
            if (requestChanel == null)
            {
                return NotFound();
            }
            return View(requestChanel);
        }

        // POST: RequestChanels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestChanelId,Title")] RequestChanel requestChanel)
        {
            if (id != requestChanel.RequestChanelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestChanel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestChanelExists(requestChanel.RequestChanelId))
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
            return View(requestChanel);
        }

        // GET: RequestChanels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestChanel = await _context.RequestChanels
                .FirstOrDefaultAsync(m => m.RequestChanelId == id);
            if (requestChanel == null)
            {
                return NotFound();
            }

            return View(requestChanel);
        }

        // POST: RequestChanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestChanel = await _context.RequestChanels.FindAsync(id);
            _context.RequestChanels.Remove(requestChanel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestChanelExists(int id)
        {
            return _context.RequestChanels.Any(e => e.RequestChanelId == id);
        }
    }
}
