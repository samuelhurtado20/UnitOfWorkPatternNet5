using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkPatternNet5.Data;
using UnitOfWorkPatternNet5.Interfaces;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Repositories
{
	public class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
		public CustomerRepository(UnitOfWorkPatternNet5Context repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
		{
		}

		public async Task<Customer> GetCustomerByIdAsync(int id)
		{
			return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Customer>> GetAllCustomersAsync()
		{
			return await GetAll().ToListAsync();
		}

		public async Task<List<Customer>> GetEnabledCustomersAsync()
		{
			return await GetAll().Where(x => x.Enabled == true).ToListAsync();
		}

		public async Task<List<Customer>> UpdateCustomerAsync(Customer customer)
		{
			return await UpdateCustomerAsync(customer);
		}
	}
}
