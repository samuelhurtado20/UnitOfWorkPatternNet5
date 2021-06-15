using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkPatternNet5.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class, new()
	{
		IQueryable<TEntity> GetAll();

		Task<TEntity> AddAsync(TEntity entity);

		Task<TEntity> UpdateAsync(TEntity entity);
	}
}
