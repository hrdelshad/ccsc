using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Customers;

namespace ccsc.Core.Services
{
	public class VideoService : IVideoService
	{
		private readonly CcscContext _context;
		private readonly ISubSystemService _subSystemService;
		private readonly IUserTypeService _userTypeService;
		private readonly ICustomerService _customerService;

		public VideoService(CcscContext context, ISubSystemService subSystemService, IUserTypeService userTypeService, ICustomerService customerService)
		{
			_context = context;
			_subSystemService = subSystemService;
			_userTypeService = userTypeService;
			_customerService = customerService;
		}

		public async Task<List<Video>> GetAllVideos()
		{
			var videos = await _context.Videos.ToListAsync();
			return videos;
		}

		public int AddVideo(Video video)
		{
			_context.Videos.Add(video);
			_context.SaveChanges();
			return video.VideoId;
		}

		public async Task UpdateVideoAsync(Video updatedVideo, List<int> subSystemIds, List<int> userTypeIds, List<int> customerIds)
		{
			updatedVideo.SubSystems = await _subSystemService.GetSubSystemsByIds(subSystemIds);
			updatedVideo.UserTypes = await _userTypeService.GetUserTypesByIds(userTypeIds);
			updatedVideo.Customers = await _customerService.GetCustomersByIds(customerIds);

			_context.Update(updatedVideo);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveVideoRelatedAsync(Video video)
		{

			var subSystems = GetSubSystemsOfVideo(video.VideoId);
			var userTypes = GetUserTypesForVideo(video.VideoId);
			var customers = GetCustomersForVideo(video.VideoId);
			
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
			if (customers.Any())
			{
				foreach (var c in customers)
				{
					video.Customers.Remove(c);
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

		public List<SubSystem> GetSubSystemsOfVideo(int id)
		{
			List<SubSystem> videoSubSystems = new List<SubSystem>();
			videoSubSystems = _context.SubSystems
				.Include(s => s.Videos)
				.Where(s => s.Videos.Any(v => v.VideoId == id))
				.ToList();

			return videoSubSystems;
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

		public List<Customer> GetCustomersForVideo(int id)
		{
			List<Customer> videoCustomers = new List<Customer>();
			videoCustomers = _context.Customers
				.Include(u => u.Videos)
				.Where(u => u.Videos.Any(v => v.VideoId == id))
				.ToList();

			return videoCustomers;
		}
		public Task<List<Customer>> GetCustomersByIds(List<int> customerIds)
		{
			throw new System.NotImplementedException();
		}


		public async Task AddVideo(Video newVideo, List<int> subSystemIds, List<int> userTypeIds, List<int> universities)
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
					SubSystems = await _subSystemService.GetSubSystemsByIds(subSystemIds),
					UserTypes = await _userTypeService.GetUserTypesByIds(userTypeIds),
					Customers = await _customerService.GetCustomersByIds(userTypeIds)
				}
			); 
			_context.SaveChanges();
		}

	}
}
