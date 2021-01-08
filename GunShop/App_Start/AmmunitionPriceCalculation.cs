using GunShop.Domai.Interfaces;
using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;
using GunShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.App_Start
{
    public class AmmunitionPriceCalculation : IPriceCalculation
    {
        private IGunRepository _gunRepository;
       

        public AmmunitionPriceCalculation(IGunRepository gunRepository)
        {
            _gunRepository = gunRepository;

        }
        public Decimal CalculatePrice(Gun gun)
        {
            return gun.Price;
        }
        public List<PriceComponent> CalculatePrices(PriceCalculationParameters parameters)
        {
            var gun = _gunRepository.GetPrice(parameters.gun.Price);

            var newPriceComponents = new List<PriceComponent>();

            if (parameters.Tracer == true)
            {
                newPriceComponents.Add(new PriceComponent { Name = "Tracet", Value = 100 });
            }
            if (parameters.Hollowpoint == true)
            {
                newPriceComponents.Add(new PriceComponent { Name = "Hollowpoint", Value = 110 });
            }

            if (parameters.Incendiary == true)
            {
                newPriceComponents.Add(new PriceComponent { Name = "Incendiary", Value = 120 });
            }
            return newPriceComponents;
        }
        }
}