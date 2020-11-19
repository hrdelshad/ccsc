using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Requests;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Controllers
{
    [Authorize]
    public class RequestChannelsController : Controller
    {
        private readonly CcscContext _context;

        public RequestChannelsController(CcscContext context)
        {
            _context = context;
        }

        // GET: RequestChannels
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestChannels.ToListAsync());
        }

        // GET: RequestChannels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestChannel = await _context.RequestChannels
                .FirstOrDefaultAsync(m => m.RequestChannelId == id);
            if (requestChannel == null)
            {
                return NotFound();
            }

            return View(requestChannel);
        }

        // GET: RequestChannels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestChannels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestChannelId,Title")] RequestChannel requestChannel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestChannel);
        }

        // GET: RequestChannels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestChannel = await _context.RequestChannels.FindAsync(id);
            if (requestChannel == null)
            {
                return NotFound();
            }
            return View(requestChannel);
        }

        // POST: RequestChannels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestChannelId,Title")] RequestChannel requestChannel)
        {
            if (id != requestChannel.RequestChannelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestChannel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestChannelExists(requestChannel.RequestChannelId))
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
            return View(requestChannel);
        }

        // GET: RequestChannels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestChannel = await _context.RequestChannels
                .FirstOrDefaultAsync(m => m.RequestChannelId == id);
            if (requestChannel == null)
            {
                return NotFound();
            }

            return View(requestChannel);
        }

        // POST: RequestChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestChannel = await _context.RequestChannels.FindAsync(id);
            _context.RequestChannels.Remove(requestChannel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestChannelExists(int id)
        {
            return _context.RequestChannels.Any(e => e.RequestChannelId == id);
        }
    }
}
