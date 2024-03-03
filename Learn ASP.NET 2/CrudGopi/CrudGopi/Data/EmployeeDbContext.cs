using CrudGopi.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace CrudGopi.Data
{
	public class EmployeeDbContext : DbContext
	{
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

	}
}