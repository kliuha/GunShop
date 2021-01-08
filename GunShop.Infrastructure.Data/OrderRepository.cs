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
            using (var ctx = new OrderContext())
            {
                ctx.Orders.Add(order);

                ctx.SaveChanges();
            }
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);
           
        }
        public List<Order> GetAllOrders()
        {
            return db.Orders.ToList();
           
        }
        public void Update (Order order)
        {
            db.Orders.Attach(order);
            db.Entry(order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
