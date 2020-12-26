﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core
{
   public class PriceComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
