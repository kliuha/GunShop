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
        public Decimal CalculatePrice(Gun gun)
        {
            return gun.Price;
        }

        public List<PriceComponent> CalculatePrices(PriceCalculationParameters parameters)
        {
            var components = new List<PriceComponent>();
            var gun = _gunRepository.GetGun(parameters.gun.Id);
            var guncomponent = new PriceComponent() { Name = "Main" };
            guncomponent.Value = gun.Price;
            components.Add(guncomponent);

            return components;

            
        }
    }
}
