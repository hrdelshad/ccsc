using System;
using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ccsc.DataLayer.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly CcscContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public GenericRepository(CcscContext context)
		{
			_context = context;
			this._dbSet = _context.Set<TEntity>();
		}

		public async Task AddEntity(TEntity entity)
		{
			entity.CreatedOn = DateTime.Now;
			await _dbSet.AddAsync(entity);
		}

		//public async Task<TEntity> GetEntityById(long entityId)
		//{
		//	return await _dbSet.SingleOrDefaultAsync(e => e.Id == entityId);
		//}

		public void UpdateEntity(TEntity entity)
		{
			entity.ModifiedOn = DateTime.Now;
			_dbSet.Update(entity);
		}

		//public void DeleteEntity(TEntity entity)
		//{
		//	entity.IsDelete = true;
		//	_dbSet.Update(entity);
		//}
		//public async Task DeleteEntity(long entityId)
		//{
		//	var entity = await GetEntityById(entityId);
		//	if (entity != null) DeleteEntity(entity);
		//}

		//public void RemoveEntity(TEntity entity)
		//{
		//	_dbSet.Remove(entity);
		//}

		//public async Task RemoveEntity(long entityId)
		//{
		//	var entity = await GetEntityById(entityId);
		//	if (entity != null) RemoveEntity(entity);
			
		//}

		public async ValueTask DisposeAsync()
		{
			if (_context != null)
			{
				await _context.DisposeAsync();
			}
		}

		public IQueryable<TEntity> GetQuery()
		{
			return _dbSet.AsQueryable();
		}
	}
}
