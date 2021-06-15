using System;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Data;
using UnitOfWorkPatternNet5.Interfaces;

namespace UnitOfWorkPatternNet5.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
		protected readonly UnitOfWorkPatternNet5Context _contex;

		public Repository(UnitOfWorkPatternNet5Context contex)
		{
			_contex = contex;
		}

		public IQueryable<TEntity> GetAll()
		{
			try
			{
				return _contex.Set<TEntity>();
			}
			catch (Exception ex)
			{
				throw new Exception($"Couldn't retrieve entities: {ex.Message}");
			}
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			if (entity == null)
			{
				throw new Exception($"{nameof(AddAsync)} entity must not be null");
			}

			try
			{
				await _contex.AddAsync(entity);
				await _contex.SaveChangesAsync();

				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
			}
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			if (entity == null)
			{
				throw new Exception($"{nameof(UpdateAsync)} entity must not be null");
			}

			try
			{
				_contex.Update(entity);
				await _contex.SaveChangesAsync();

				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
			}
		}
	}
}
