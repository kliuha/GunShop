using GunShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Services.Interfaces;
using GunShop.Domai.Interfaces;
using GunShop.Domain.Core.OrderAggregate;

namespace GunShop.Infrastructure.Bussiness
{
   public class OrderService : IOrderService
    {
        private IGunRepository gunRepository;
        private IPriceCalculation _priceCalculation;
        private IOrderRepository orderRepository;
        public OrderService(IGunRepository gunRepo, IPriceCalculation priceCalculation,
            IOrderRepository orderRepo)
        {
            gunRepository = gunRepo;
            orderRepository = orderRepo;
            _priceCalculation = priceCalculation;
            
        }
        public Order CreateOrder(int Id, string firstName, string lastName,PriceCalculationParameters parameters)
        {
            var guns = gunRepository.GetGun(Id);
            var newOrder = new Order
            {
                GunId = guns.Id,
                FirstName = firstName,
                LastName = lastName,
                PriceComponents = new List<PriceComponent>(),
            };
            newOrder.PriceComponents = _priceCalculation.CalculatePrices(parameters);
            guns.Id = newOrder.GunId;
          
            orderRepository.Create(newOrder);
            return newOrder;
        }
    }
}
