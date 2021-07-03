using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using Microsoft.AspNetCore.Authorization;
using ccsc.Core.Services.Interfaces;

namespace ccsc.Web.Controllers
{
    [Authorize]
    public class ChangeSetsController : BaseController
    {
        private readonly CcscContext _context;
        private readonly ITfsService _service;
        private readonly IChangeSetService _changeSetService;
        private readonly ISubSystemService _subSystemService;
        private readonly IUserTypeService _userTypeService;

        public ChangeSetsController(CcscContext context, ITfsService service, IChangeSetService changeSetService, ISubSystemService subSystemService, IUserTypeService userTypeService)
        {
	        _context = context;
	        _service = service;
	        _changeSetService = changeSetService;
	        _subSystemService = subSystemService;
	        _userTypeService = userTypeService;
        }



		// GET: ChangeSets
		public async Task<IActionResult> Index()
        {
            var changeSets = await _changeSetService.GetChangeSets()
                .OrderByDescending(c=>c.ChangeSetId).ToListAsync();
            return View(changeSets);
        }

        // GET: ChangeSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _context.ChangeSets
                .Include(c => c.AppUser)
                .Include(c => c.ChangeType)
                .Include(c => c.Video)
                .FirstOrDefaultAsync(m => m.ChangeSetId == id);
            if (changeSet == null)
            {
                return NotFound();
            }

            return View(changeSet);
        }

        // GET: ChangeSets/Create
        public async Task<IActionResult> Create()
        {
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title");
            ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
            ViewData["UserType"] = await _userTypeService.GetUserTypes();
          
            return View();
        }

        // POST: ChangeSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeSetId,AppUserId,Date,Comment,Title,Description,Version,IsPublish,Quarter,ChangeTypeId,VideoId")] ChangeSet changeSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changeSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "AppUserId", "DisplayName", changeSet.AppUserId);
            ViewData["ChangeTypeId"] = new SelectList(_context.ChangeTypes, "ChangeTypeId", "Title", changeSet.ChangeTypeId);
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title", changeSet.VideoId);
            return View(changeSet);
        }

        // GET: ChangeSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _context.ChangeSets.FindAsync(id);
            if (changeSet == null)
            {
                return NotFound();
            }
          
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "AppUserId", "DisplayName", changeSet.AppUserId);
            ViewData["ChangeTypeId"] = new SelectList(_context.ChangeTypes, "ChangeTypeId", "Title", changeSet.ChangeTypeId);
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title", changeSet.VideoId);
            ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
            ViewData["UserType"] = await _userTypeService.GetUserTypes();
            ViewData["SelectedSubSystem"] = await _subSystemService.GetCurrentSubSystems("ChangeSet",id.Value);
            ViewData["SelectedUserType"] = await _userTypeService.GetCurrentUserTypes("ChangeSet", id.Value);
            return View(changeSet);
        }

        // POST: ChangeSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeSetId,AppUserId,Date,Comment,Title,Description,Version,IsPublish,Quarter,ChangeTypeId,VideoId")] ChangeSet inputChangeSet, List<int> selectedSubSystems, List<int> selectedUserTypes)
        {
            if (id != inputChangeSet.ChangeSetId)
            {
                return NotFound();
            }

            var changeSet =  _changeSetService.GetChangeSets()
	            .Where(e=>e.ChangeSetId == id)
	            .Include(e=>e.SubSystems)
	            .Include(e=>e.UserTypes)
	            .Single(e=>e.ChangeSetId == id);

            changeSet.Date = inputChangeSet.Date;
            changeSet.Title = inputChangeSet.Title;
            changeSet.Description = inputChangeSet.Description;
            changeSet.Version = inputChangeSet.Version;
            changeSet.IsPublish = inputChangeSet.IsPublish;
            changeSet.Quarter = inputChangeSet.Quarter;
            changeSet.ChangeTypeId = inputChangeSet.ChangeTypeId;
            changeSet.VideoId = inputChangeSet.VideoId;

            if (ModelState.IsValid)
            {
                try
                {
	                await _changeSetService.RemoveRelatedAsync(changeSet);

	                await _changeSetService.UpdateAsync(changeSet, selectedSubSystems, selectedUserTypes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_changeSetService.ChangeSetExists(id))
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
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "AppUserId", "DisplayName", changeSet.AppUserId);
            ViewData["ChangeTypeId"] = new SelectList(_context.ChangeTypes, "ChangeTypeId", "Title", changeSet.ChangeTypeId);
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "Title", changeSet.VideoId);
            ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
            ViewData["UserType"] = await _userTypeService.GetUserTypes();
            ViewData["SelectedSubSystem"] = await _subSystemService.GetSubSystemsOfFaq(id);
            ViewData["SelectedUserType"] = await _userTypeService.GetUserTypesForFaq(id);
            return View(changeSet);
        }

        // GET: ChangeSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _context.ChangeSets
                .Include(c => c.AppUser)
                .Include(c => c.ChangeType)
                .Include(c => c.Video)
                .FirstOrDefaultAsync(m => m.ChangeSetId == id);
            if (changeSet == null)
            {
                return NotFound();
            }

            return View(changeSet);
        }

        // POST: ChangeSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var changeSet = await _context.ChangeSets.FindAsync(id);
            _context.ChangeSets.Remove(changeSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		//private bool ChangeSetExists(int id)
		//{
		//	return _context.ChangeSets.Any(e => e.ChangeSetId == id);
		//}

		public async Task<IActionResult> TfsIndex()
        {
            var result = await _service.GetChangeSets();
            var newChangeSets = result;
			foreach (var item in newChangeSets)
			{
				if (!_changeSetService.ChangeSetExists(item.ChangeSetId))
				{
					_changeSetService.AddChangeSetFromTfs(item);
				}
			}

            return View(newChangeSets);
        }
    }
}
