using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.Models
{
    public class BuyModel
    {
       public Gun Gun { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GunId { get; set; }
        public int OrderId { get; set; }
        public int inStock { get; set; }
        public int Quantity { get; set; }

        public bool Tracer { get; set; }
        public bool Hollowpoint { get; set; }
        public bool Incendiary { get; set; }
        public List<PriceComponent> PriceComponents { get; set; }
    }
}
