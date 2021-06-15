using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Interfaces;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<List<Customer>> GetAllCustomersAsync()
		{
			return await _customerRepository.GetAllCustomersAsync();
		}

		public async Task<Customer> GetCustomerByIdAsync(int id)
		{
			return await _customerRepository.GetCustomerByIdAsync(id);
		}

		public async Task<Customer> AddCustomerAsync(Customer newCustomer)
		{
			return await _customerRepository.AddAsync(newCustomer);
		}

		public async Task<List<Customer>> GetEnabledCustomersAsync()
		{
			return await _customerRepository.GetEnabledCustomersAsync();
		}

		public async Task<Customer> UpdateCustomerAsync(Customer customer)
		{
			return await _customerRepository.UpdateAsync(customer);
		}

		public async Task<Customer> AddAsync(Customer customer)
		{
			return await _customerRepository.AddAsync(customer);
		}
	}
}
