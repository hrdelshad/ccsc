using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface IVideoService
	{
		#region SubSystem

		Task<List<Video>> GetAllVideos();

		int AddVideo(Video video);
		Task AddVideo(Video newVideo, List<int> subSystemIds, List<int> userTypeIds);
		Task UpdateVideoAsync(Video updatedVideo, List<int> subSystemIds, List<int> userTypeIds);
		Task RemoveVideoRelatedAsync(Video updatedVideo);
		void RemoveSubSystemsFromVideo(int id, List<int> subSystemIds);
		List<SubSystem> GetSubSystemsOfVideo(int videoId);
		List<UserType> GetUserTypesForVideo(int id);
	

		#endregion
	}
}