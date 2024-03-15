using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Models.Data
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<AnnualSalary> AnnualSalary { get; set; }
        public DbSet<SalaryPaid> SalaryPaid { get; set; }

       
    }

   
  
}

