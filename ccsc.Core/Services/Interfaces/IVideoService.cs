using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface IVideoService
	{
		#region SubSystem

		int AddVideo(Video video);
		void AddVideo(Video newVideo, List<int> subSystemIds, List<int> userTypeIds);
		Task UpdateVideoAsync(Video updatedVideo, List<int> subSystemIds, List<int> userTypeIds);
		Task RemoveVideoRelatedAsync(Video updatedVideo);
		void RemoveSubSystemsFromVideo(int id, List<int> subSystemIds);

		List<SubSystem> GetSubSystems();
		List<SubSystem> GetSubSystemsByIds(List<int> subSystemIds);
		List<SubSystem> GetSubSystemsOfVideo(int videoId);
		SubSystem GetSubSystemById(int id);

		List<UserType> GetUserTypes();
		List<UserType> GetUserTypesByIds(List<int> userTypeIds);
		List<UserType> GetUserTypesForVideo(int id);
		UserType GetUserTypeById(int id);

		#endregion
	}
}