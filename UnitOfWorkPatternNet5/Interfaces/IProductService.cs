using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetEnabledProductsAsync();

		Task<Product> GetProductByIdAsync(int id);

		Task<Product> UpdateProductAsync(Product product);

		Task<Product> AddProductAsync(Product product);
	}
}
