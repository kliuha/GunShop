using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core
{
    public class PriceCalculationParameters
    {       
        public Gun gun { get; set; }
        public bool Tracer { get; set; }
        public bool Hollowpoint { get; set; }
        public bool Incendiary { get; set; }

    }
}
