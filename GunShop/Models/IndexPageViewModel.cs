using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GunShop.Infrastructure.Data;
using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;

namespace GunShop.Models
{
    public class IndexPageViewModel
    {
        

        public Gun _Gun { get; set; }
        public List<Gun> Gun { get; set; }
        public Dictionary<int,Gun > Guns { get; set; }
        public Dictionary<int, Warehouse> Ware { get; set; }
        public List<PriceComponent> PriceComponents { get; set; }
        public bool Tracer { get; set; }
        public bool Hollowpoint { get; set; }
        public bool Incendiary { get; set; }

    }
}