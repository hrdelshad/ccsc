using System;
using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Common;

namespace ccsc.DataLayer.Repository
{
	public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
	{
		IQueryable<TEntity> GetQuery();
		Task AddEntity(TEntity entity);
		//Task<TEntity> GetEntityById(long entityId);
		void UpdateEntity(TEntity entity);
		//void DeleteEntity(TEntity entity);
		//Task DeleteEntity(long entityId);

		//void RemoveEntity(TEntity entity);
		//Task RemoveEntity(long entityId);
	}
}
