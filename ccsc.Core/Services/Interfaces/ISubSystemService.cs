using ccsc.DataLayer.Entities.ChangeSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	interface ISubSystemService
	{
		List<SubSystem> GetSubSystems();
		List<SubSystem> GetSubSystemsByIds(List<int> subSystemIds);
		List<SubSystem> GetSubSystemsForChangeSet(int id);
		SubSystem GetSubSystemById(int id);
	}
}
