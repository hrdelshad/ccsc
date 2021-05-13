using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;

namespace ccsc.Core.Services.Interfaces
{
	public interface IContractService
	{
		int AddContract(Contract contract);
		Task AddContract(Contract newContract, List<int> selectedSubSystems);
		Task UpdateContractAsync(Contract updatedContract, List<int> subSystemIds);
		Task RemoveContractRelatedAsync(Contract contract);
		List<SubSystem> GetSubSystemsOfContract(int contract);
	}
}
