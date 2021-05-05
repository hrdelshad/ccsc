using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface IFaqService
	{
		#region SubSystem

		int AddFaq(Faq faq);
		void AddFaq(Faq newFaq, List<int> subSystemIds, List<int> userTypeIds);
		Task UpdateFaqAsync(Faq updatedFaq, List<int> subSystemIds, List<int> userTypeIds);
		Task RemoveFaqRelatedAsync(Faq updatedFaq);
		void RemoveSubSystemsFromFaq(int id, List<int> subSystemIds);

		List<SubSystem> GetSubSystems();
		List<SubSystem> GetSubSystemsByIds(List<int> subSystemIds);
		List<SubSystem> GetSubSystemsOfFaq(int faqId);
		SubSystem GetSubSystemById(int id);

		List<UserType> GetUserTypes();
		List<UserType> GetUserTypesByIds(List<int> userTypeIds);
		List<UserType> GetUserTypesForFaq(int id);
		UserType GetUserTypeById(int id);

		#endregion
	}
}