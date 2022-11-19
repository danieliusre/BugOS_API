using Microsoft.EntityFrameworkCore;

namespace POSApi.Models
{
    public class POSContext : DbContext
    {
        public POSContext(DbContextOptions<POSContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePermissions> EmployeePermissions { get; set; }
        public DbSet<EventHistory> EventHistories { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                    new Customer()
                    {
                        Id = 1,
                        Name = "John",
                        Lastname = "Smith",
                        Email = "John.Smith@gmail.com",
                        Password = "1",
                        Address = " adresas "
                    },
                    new Customer()
                    {
                        Id = 2,
                        Name = "Jane",
                        Lastname = "Doe",
                        Email = "Jane.Doe@gmail.com",
                        Password = "22",
                        Address = " adresas2 "
                    }
                );
            modelBuilder.Entity<Customer>().HasData(
                    new Product()
                    {
                        Id = 1,
                        Name = "product1",
                        Description = "aaaaaaaaaaaa",
                        Price = 1,
                        Stock = 1,
                        Barcode = "a1a1a1a1a1",
                        Category = 1,
                        Discount = 1
                    }
                );
        }
    }
}
