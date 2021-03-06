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

		public VideosController(CcscContext context, IVideoService videoService)
		{
			_context = context;
			_videoService = videoService;
		}

		// GET: Videos
		public async Task<IActionResult> Index()
		{
			return View(await _context.Videos.ToListAsync());
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
		public IActionResult Create()
		{
			ViewData["SubSystem"] = _videoService.GetSubSystems();
			ViewData["UserType"] = _videoService.GetUserTypes();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("VideoId,Title,Path,PosterPath,Description,PublishedOn,ModifiedOn,Publish,SubSystems")] Video video, List<int> selectedSubSystems, List<int> selectedUserTypes)
		{
			if (ModelState.IsValid)
			{
				_videoService.AddVideo(video, selectedSubSystems, selectedUserTypes);
				//await _context.SaveChangesAsync();
				//_videoService.AddSubSystemsToVideo(SelectedSubSystems, videoId);
				//_videoService.AddUserTypesToVideo(SelectedUserTypes, videoId);
				return RedirectToAction(nameof(Index));
			}
			return View(video);
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
			ViewData["SubSystem"] = _videoService.GetSubSystems();
			ViewData["UserType"] = _videoService.GetUserTypes();
			ViewData["SelectedSubSystem"] = _videoService.GetSubSystemsForVideo(id.Value);
			ViewData["SelectedUserType"] = _videoService.GetUserTypesForVideo(id.Value);
			return View(video);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("VideoId,Title,Path,PosterPath,Description,PublishedOn,ModifiedOn,Publish")] Video video, List<int> selectedSubSystems, List<int> selectedUserTypes)
		{
			var updatedVideo = _context.Videos
								   .Include(v => v.SubSystems)
								   .Include(v => v.UserTypes)
								   .Single(v => v.VideoId == id) ?? throw new ArgumentNullException("_context.Videos\r\n\t\t        .Include(v => v.SubSystems)\r\n\t\t        .Include(v => v.UserTypes)\r\n\t\t        .Where(v => v.VideoId == id).Single()");
				
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

					await _videoService.UpdateVideoAsync(updatedVideo, selectedSubSystems, selectedUserTypes);
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
