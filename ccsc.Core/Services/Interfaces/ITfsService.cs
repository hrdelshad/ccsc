using ccsc.Core.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface ITfsService
	{
		Task<IQueryable<TfsChangeSetViewModel>> GetChangeSets();
	}
}