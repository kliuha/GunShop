﻿using GunShop.Domain.Core.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core
{
   public class Order
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PriceComponent> PriceComponents { get; set; }      
    }
}
