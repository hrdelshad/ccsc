using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.DTOs;
using ccsc.DataLayer.Entities.ChangeSets;

namespace ccsc.Core.Services.Interfaces
{
	public interface ITfsService
	{
		Task<IQueryable<TfsChangeSetViewModel>> GetChangeSets();
	}
}