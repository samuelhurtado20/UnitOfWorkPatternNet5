using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Interfaces;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _productRepository.GetProductByIdAsync(id);
		}

		public async Task<List<Product>> GetEnabledProductsAsync()
		{
			return await _productRepository.GetEnabledProductsAsync();
		}

		public async Task<Product> UpdateProductAsync(Product product)
		{
			return await _productRepository.UpdateProductAsync(product);
		}

		public async Task<Product> AddProductAsync(Product product)
		{
			return await _productRepository.AddProductAsync(product);
		}
	}
}
