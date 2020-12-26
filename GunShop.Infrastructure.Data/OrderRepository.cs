using GunShop.Domain.Core;
using GunShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private OrderContext db;
        public OrderRepository()
        {
            this.db = new OrderContext();
        }
        public void Create(Order order)
        {
            db.Orders.Add(order);
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }
    }
}
