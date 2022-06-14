using Microsoft.EntityFrameworkCore;
using RebelTask.DataAccess.EntitiyConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTask.DataAccess.Models
{
   public class RebelTasksContext : DbContext
    {
        private const string ConnectionString = "Server=.;Database=RebelTasksDb;User Id=sa;Password=12345;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }

    }
}
