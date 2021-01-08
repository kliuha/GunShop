using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Domain.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GunShop.Domain.Core.OrderAggregate;

namespace GunShop.Infrastructure.Data
{
    class OrderContext : DbContext
    {
        public OrderContext() : base("GunShop")
        {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderContext, Migrations.Configuration>());
        }
        public DbSet<Gun> Guns { get; set; }      
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }      
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<PriceComponent> PriceComponents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                    

            modelBuilder.Entity<Warehouse>();

        }
    }
}
