using CoreTestApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreTestApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
        public DbSet<Employee>Employees { get; set; }
    }
}
