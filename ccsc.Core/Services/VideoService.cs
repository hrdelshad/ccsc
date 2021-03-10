using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Core.Services
{
	public class VideoService : IVideoService
	{
		private CcscContext _context;

		public VideoService(CcscContext context)
		{
			_context = context;
		}

		public int AddVideo(Video video)
		{
			_context.Videos.Add(video);
			_context.SaveChanges();
			return video.VideoId;
		}

		public async Task UpdateVideoAsync(Video updatedVideo, List<int> subSystemIds, List<int> userTypeIds)
		{
			//updatedVideo.SubSystems = null;
			//updatedVideo.UserTypes = null;
			updatedVideo.SubSystems = GetSubSystemsByIds(subSystemIds);
			updatedVideo.UserTypes = GetUserTypesByIds(userTypeIds);

			_context.Update(updatedVideo);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveVideoRelatedAsync(Video video)
		{

			var subSystems = GetSubSystemsOfVideo(video.VideoId);
			var userTypes = GetUserTypesForVideo(video.VideoId);
			
			if (subSystems.Any())
			{
				foreach (var ss in subSystems)
				{
					video.SubSystems.Remove(ss);
					_context.Update(video);
					await _context.SaveChangesAsync();
				}
			}

			if (userTypes.Any())
			{
				foreach (var ut in userTypes)
				{
					video.UserTypes.Remove(ut);
					_context.Update(video);
					await _context.SaveChangesAsync();
				}
			}
		}

		public void RemoveSubSystemsFromVideo(int videoId, List<int> subSystemIds)
		{
			foreach (int subSystemId in subSystemIds)
			{
				_context.Videos.Find(videoId).SubSystems.Remove(_context.SubSystems.Find(subSystemId));
			}
			_context.SaveChanges();
		}

		public List<SubSystem> GetSubSystems()
		{
			return _context.SubSystems.ToList();
		}

		public List<SubSystem> GetSubSystemsByIds(List<int> subSystemIds)
		{
			List<SubSystem> subSystems = new List<SubSystem>();
			foreach (int id in subSystemIds)
			{
				var ss = GetSubSystemById(id);
				subSystems.Add(ss);
			}

			return subSystems;
		}

		public List<SubSystem> GetSubSystemsOfVideo(int id)
		{
			List<SubSystem> videoSubSystems = new List<SubSystem>();
			videoSubSystems = _context.SubSystems
				.Include(s => s.Videos)
				.Where(s => s.Videos.Any(v => v.VideoId == id))
				.ToList();

			return videoSubSystems;
		}

		public SubSystem GetSubSystemById(int id)
		{
			return _context.SubSystems.Find(id);
		}

		public List<UserType> GetUserTypes()
		{
			return _context.UserTypes.ToList();
		}

		public List<UserType> GetUserTypesByIds(List<int> userTypeIds)
		{
			List<UserType> userTypes = new List<UserType>();
			foreach (int id in userTypeIds)
			{
				var ut = GetUserTypeById(id);
				userTypes.Add(ut);
			}

			return userTypes;
		}

		public List<UserType> GetUserTypesForVideo(int id)
		{
			List<UserType> videoUserTypes = new List<UserType>();
			videoUserTypes = _context.UserTypes
				.Include(u => u.Videos)
				.Where(u => u.Videos.Any(v => v.VideoId == id))
				.ToList();

			return videoUserTypes;
		}

		public UserType GetUserTypeById(int id)
		{
			return _context.UserTypes.Find(id);
		}

		public void AddVideo(Video newVideo, List<int> subSystemIds, List<int> userTypeIds)
		{
			_context.AddRange(
				new Video
				{
					Title = newVideo.Title,
					Path = newVideo.Path,
					PosterPath = newVideo.PosterPath,
					PublishedOn = newVideo.PublishedOn,
					ModifiedOn = newVideo.PublishedOn,
					Description = newVideo.Description,
					Publish = newVideo.Publish,
					SubSystems = GetSubSystemsByIds(subSystemIds),
					UserTypes = GetUserTypesByIds(userTypeIds)
				}
			);
			_context.SaveChanges();
		}

	}
}
