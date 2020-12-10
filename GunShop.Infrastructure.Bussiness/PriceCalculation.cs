using GunShop.Domain.Core;
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
        List<IPriceCalculation> _priceCalculationStrategies;

            public PriceCalculation(List<IPriceCalculation> priceCalculationStrategies)
            {
                _priceCalculationStrategies = priceCalculationStrategies;
            }
       public List<Gun> CalculatePrice(Gun gun)
        {

            List<Gun> components = null;
            

            foreach (IPriceCalculation priceCalculationStrategy in _priceCalculationStrategies)
            {
                var price = priceCalculationStrategy.CalculatePrice(gun);
                if (price != null)
                {
                    if (components == null)
                    {
                        components = price;
                    }
                    else
                    {
                        components.AddRange(price);
                    }
                }
            }
            return components;
        }
    }
}
