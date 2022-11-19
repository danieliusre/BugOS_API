using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace PRADaAPI
{
    public class POSContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public POSContext (DbContextOptions<POSContext> opt) : base(opt)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EmployeePermissions> EmployeePermissions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EventHistory> EventHistories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Incident> Incidents { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Shift> Shifts { get; set; }
    }
}
