using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Data;
using UnitOfWorkPatternNet5.Interfaces;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(UnitOfWorkPatternNet5Context repoContext) : base(repoContext)
		{
		}

		public Task<Product> GetProductByIdAsync(int id)
		{
			return GetAll().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Product>> GetEnabledProductsAsync()
		{
			return await GetAll().Where(x => x.Enabled).ToListAsync();
		}

		public async Task<Product> UpdateProductAsync(Product product)
		{
			return await UpdateAsync(product);
		}

		public async Task<Product> AddProductAsync(Product product)
		{
			return await AddAsync(product);
		}
	}
}
