using Microsoft.EntityFrameworkCore;
using UnitOfWorkPatternNet5.Models;

namespace UnitOfWorkPatternNet5.Data
{
	public class UnitOfWorkPatternNet5Context : DbContext
	{
		public UnitOfWorkPatternNet5Context(DbContextOptions<UnitOfWorkPatternNet5Context> options)
			: base(options)
		{
		}

		public DbSet<Customer> Customer { get; set; }

		public DbSet<Product> Product { get; set; }
	}
}
