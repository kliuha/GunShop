using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Domain.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GunShop.Infrastructure.Data
{
    class OrderContext : DbContext
    {
        public OrderContext() : base("GunShop")
        {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderContext, Migrations.Configuration>());
        }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Ammunition> Ammunitions { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<PriceComponent> PriceComponents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Gun>().HasMany(t => t.Ammunitions).WithRequired(c => c.Guns);

            modelBuilder.Entity<Order>().HasMany(x => x.PriceComponents).WithRequired(x => x.Order);

            modelBuilder.Entity<Warehouse>().HasMany(x => x.Guns).WithRequired(x => x.Warehouses);

        }
    }
}
