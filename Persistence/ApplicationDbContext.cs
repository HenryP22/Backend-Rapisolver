using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RapiSolver.Entity;
using RapiSolver.Persistence.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CreditCardConfig(builder.Entity<CreditCard>());
            new CustomerConfig(builder.Entity<Customer>());
            new LocationConfig(builder.Entity<Location>());
            new PaymentConfig(builder.Entity<Payment>());
            new UserConfig(builder.Entity<User>());
            new ReservationConfig(builder.Entity<Reservation>());
            new ServiceConfig(builder.Entity<Service>());
            new ServiceCategoryConfig(builder.Entity<ServiceCategory>());
            new SupplierConfig(builder.Entity<Supplier>());
        }
    }

   
}
