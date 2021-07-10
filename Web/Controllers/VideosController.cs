using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class VideosController : Controller
	{
		private readonly CcscContext _context;
		private readonly IVideoService _videoService;
		private readonly ISubSystemService _subSystemService;
		private readonly IUserTypeService _userTypeService;
		private readonly ICustomerService _customerService;

		public VideosController(CcscContext context, IVideoService videoService, ISubSystemService subSystemService, IUserTypeService userTypeService, ICustomerService customerService)
		{
			_context = context;
			_videoService = videoService;
			_subSystemService = subSystemService;
			_userTypeService = userTypeService;
			_customerService = customerService;
		}

		// GET: Videos
		public async Task<IActionResult> Index()
		{
			var videos = await _videoService.GetAllVideos();
			return View(videos);
		}

		// GET: Videos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var video = await _context.Videos
				.FirstOrDefaultAsync(m => m.VideoId == id);
			if (video == null)
			{
				return NotFound();
			}

			return View(video);
		}

		// GET: Videos/Create
		public async Task<IActionResult> Create()
		{
			ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
			ViewData["UserType"] = await _userTypeService.GetUserTypes();
			ViewData["Customer"] = await _customerService.GetCustomers();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("VideoId,Title,Path,PosterPath,Description,PublishedOn,ModifiedOn,Publish,SubSystems")] Video video, List<int> selectedSubSystems, List<int> selectedUserTypes, List<int> selectedUniversities)
		{
			if (!ModelState.IsValid) return View(video);
			await _videoService.AddVideo(video, selectedSubSystems, selectedUserTypes, selectedUniversities);
			return RedirectToAction(nameof(Index));
		}

		// GET: Videos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var video = await _context.Videos.FindAsync(id);
			if (video == null)
			{
				return NotFound();
			}
			ViewData["SubSystem"] = await _subSystemService.GetSubSystems();
			ViewData["UserType"] = await _userTypeService.GetUserTypes();
			ViewData["Customer"] = await _customerService.GetCustomers();
			ViewData["SelectedSubSystem"] = _videoService.GetSubSystemsOfVideo(id.Value);
			ViewData["SelectedUserType"] = _videoService.GetUserTypesForVideo(id.Value);
			ViewData["SelectedCustomers"] = _videoService.GetCustomersForVideo(id.Value);
			return View(video);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("VideoId,Title,Path,PosterPath,Description,PublishedOn,ModifiedOn,Publish")] Video video, List<int> selectedSubSystems, List<int> selectedUserTypes, List<int> selectedCustomers)
		{
			var updatedVideo = _context.Videos
								   .Include(v => v.SubSystems)
								   .Include(v => v.UserTypes)
								   .Include(v=>v.Customers)
								   .Single(v => v.VideoId == id) ?? throw new ArgumentNullException("_context.Videos\r\n\t\t        .Include(v => v.SubSystems)\r\n\t\t        .Include(v => v.UserTypes)\r\n\t\t        .Include(v => v.Customers)\r\n\t\t        .Where(v => v.VideoId == id).Single()");
				
				updatedVideo.Description = video.Description;
				updatedVideo.ModifiedOn = DateTime.Now;
				updatedVideo.Path = video.Path;
				updatedVideo.PosterPath = video.PosterPath;
				updatedVideo.Publish = video.Publish;
				updatedVideo.PublishedOn = video.PublishedOn;
				updatedVideo.Title = video.Title;
			

			if (id != video.VideoId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _videoService.RemoveVideoRelatedAsync(updatedVideo);

					await _videoService.UpdateVideoAsync(updatedVideo, selectedSubSystems, selectedUserTypes, selectedCustomers);
				}

				catch (DbUpdateConcurrencyException)
				{
					if (!VideoExists(video.VideoId))
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
			return View(video);
		}

		// GET: Videos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var video = await _context.Videos
				.FirstOrDefaultAsync(m => m.VideoId == id);
			if (video == null)
			{
				return NotFound();
			}

			return View(video);
		}

		// POST: Videos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var video = await _context.Videos.FindAsync(id);
			_context.Videos.Remove(video);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool VideoExists(int id)
		{
			return _context.Videos.Any(e => e.VideoId == id);
		}
	}
}
