using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Interfaces;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetEnabledProductsAsync()
		{
			try
			{
				return await _productService.GetEnabledProductsAsync();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
		{
			try
			{
				var product = await _productService.GetProductByIdAsync(id);

				if (product == null)
				{
					return NotFound();
				}

				return product;
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="product"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProductAsync(int id, Product product)
		{
			if (id != product.Id)
			{
				return BadRequest();
			}

			try
			{
				await _productService.UpdateProductAsync(product);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExistsAsync(id).Result)
				{
					return NotFound();
				}
				else
				{
					return StatusCode(StatusCodes.Status500InternalServerError);
				}
			}

			return NoContent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Product>> AddProductAsync(Product product)
		{
			try
			{
				await _productService.AddProductAsync(product);

				return Ok(product);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		private async Task<bool> ProductExistsAsync(int id)
		{
			try
			{
				return await _productService.GetProductByIdAsync(id) is Product;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
