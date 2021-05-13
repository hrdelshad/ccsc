using ccsc.DataLayer.Entities.ChangeSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface ISubSystemService
	{
		Task<List<SubSystem>> GetSubSystems();
		Task<List<SubSystem>> GetSubSystemsByIds(List<int> subSystemIds);
		Task<SubSystem> GetSubSystemById(int id);

		Task<List<SubSystem>> GetSubSystemsOfFaq(int faqId);
		Task<List<SubSystem>> GetCurrentSubSystems(string entity, int id);
	}
}
