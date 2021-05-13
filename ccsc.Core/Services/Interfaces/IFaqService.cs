using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface IFaqService
	{

		int AddFaq(Faq faq);
		Task AddFaqAsync(Faq newFaq, List<int> subSystemIds, List<int> userTypeIds);
		Task UpdateFaqAsync(Faq updatedFaq, List<int> subSystemIds, List<int> userTypeIds);
		Task RemoveFaqRelatedAsync(Faq updatedFaq);
		void RemoveSubSystemsFromFaq(int id, List<int> subSystemIds);
	}
}