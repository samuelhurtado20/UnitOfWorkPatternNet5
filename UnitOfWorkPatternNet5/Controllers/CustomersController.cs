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
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync()
		{
			try
			{
				return await _customerService.GetAllCustomersAsync();
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
		public async Task<ActionResult<Customer>> GetCustomerByIdAsync(int id)
		{
			try
			{
				var customer = await _customerService.GetCustomerByIdAsync(id);

				if (customer == null)
				{
					return NotFound();
				}

				return customer;
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet("GetEnabledCustomersAsync/")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetEnabledCustomersAsync()
		{
			try
			{
				return await _customerService.GetEnabledCustomersAsync();
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
		/// <param name="customer"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomerAsync(int id, Customer customer)
		{
			try
			{
				if (id != customer.Id)
				{
					return BadRequest();
				}

				await _customerService.UpdateCustomerAsync(customer);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CustomerExistsAsync(id).Result)
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
		/// <param name="customer"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Customer>> AddCustomerAsync(Customer customer)
		{
			try
			{
				await _customerService.AddAsync(customer);

				return Ok(customer);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		private async Task<bool> CustomerExistsAsync(int id)
		{
			try
			{
				return await _customerService.GetCustomerByIdAsync(id) is Customer;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
