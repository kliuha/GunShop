using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GunShop.Domain.Core;
using GunShop.Services.Interfaces;
using System.Threading.Tasks;
using GunShop.Domai.Interfaces;

namespace GunShop.Infrastructure.Data
{
   public class WarehouseRepository : IWarehouseRepository
    {
        private OrderContext db;
        public WarehouseRepository()
        {
            this.db = new OrderContext();
        }
        public List<Warehouse> GetAllWarehouses()
        {
            return db.Warehouses.ToList();

        }
    }
}
