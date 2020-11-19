using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.DTOs;

namespace ccsc.Core.Services.Interfaces
{
	public interface ITfsService
	{
		Task<IQueryable<TfsChangeSetViewModel>> GetChangeSets();
	}
}