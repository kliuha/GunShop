using GunShop.Domai.Interfaces;
using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;
using GunShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Infrastructure.Bussiness
{
    public class PriceCalculation : IPriceCalculation
    {

        private IGunRepository _gunRepository;
        public PriceCalculation(IGunRepository gunRepository)
        {

            _gunRepository = gunRepository;
        }
       

        public List<PriceComponent> CalculatePrice(PriceCalculationParameters parameters)
        {

            var components = new List<PriceComponent>();

            var gun = _gunRepository.GetGun(parameters.gun.Id);          
            var placeComponent = new PriceComponent() { Name = "Main price" };
            placeComponent.Value = gun.Price;
            components.Add(placeComponent);
            return components;
        }
    }
}
