using Microsoft.EntityFrameworkCore;

namespace WebAPIPayrollCSharp.Models{
    public class EmployeeContext : DbContext{
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options) {
            
        }
        public DbSet<Employee> Employees { get; set; }
        
        //If there is any new class, you can create a table in db for it:
        // public DbSet<Payroll> Payroll {get; set;}
    }
}