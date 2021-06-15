using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Interfaces
{
	public interface ICustomerRepository : IRepository<Customer>
	{
		Task<Customer> GetCustomerByIdAsync(int id);

		Task<List<Customer>> GetEnabledCustomersAsync();

		Task<List<Customer>> GetAllCustomersAsync();
	}
}
