using ccsc.DataLayer.Entities.ChangeSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Tutorials;

namespace ccsc.Core.Services.Interfaces
{
	public interface IUserTypeService
	{
		Task<List<UserType>> GetUserTypes();
		Task<List<UserType>> GetUserTypesByIds(List<int> subSystemIds);
		Task<UserType> GetUserTypeById(int id);

		Task<List<UserType>> GetUserTypesForFaq(int id);

		Task<List<UserType>> GetCurrentUserTypes(string entity, int id);
	}
}
