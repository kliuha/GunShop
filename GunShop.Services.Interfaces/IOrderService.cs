using GunShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GunShop.Services.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(int GunId, string firstName, string lastName,
            PriceCalculationParameters parameters);
    }
}
