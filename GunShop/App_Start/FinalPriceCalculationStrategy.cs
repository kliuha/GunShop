using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;
using GunShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.App_Start
{
    public class FinalPriceCalculationStrategy : IPriceCalculation
    {
        List<IPriceCalculation> _strategies;

        public FinalPriceCalculationStrategy(List<IPriceCalculation> strategies)
        {
            _strategies = strategies;
        }

        public List<PriceComponent> CalculatePrice(PriceCalculationParameters parameters)
        {
            var allPriceComponents = new List<PriceComponent>();

            foreach (var s in _strategies)
            {
                allPriceComponents.AddRange(s.CalculatePrice(parameters));
            }

            return allPriceComponents;
        }
    }
}