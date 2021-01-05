using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Services.Interfaces
{
    public interface IPriceCalculation
    {
        Decimal CalculatePrice(Gun gun);
        List<PriceComponent> CalculatePrices(PriceCalculationParameters parameters);
    }
}
