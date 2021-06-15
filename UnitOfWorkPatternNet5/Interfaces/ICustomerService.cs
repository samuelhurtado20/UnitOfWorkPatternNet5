using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Interfaces
{
	public interface ICustomerService
	{
		Task<List<Customer>> GetAllCustomersAsync();
		Task<Customer> GetCustomerByIdAsync(int id);
		Task<List<Customer>> GetEnabledCustomersAsync();
		Task<Customer> UpdateCustomerAsync(Customer customer);
		Task<Customer> AddAsync(Customer customer);
	}
}
