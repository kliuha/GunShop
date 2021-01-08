﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core.OrderAggregate
{
    public class PriceComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int GunId { get; set; }
        public Gun Gun { get; set; }
    }
}
