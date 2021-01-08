﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core
{
    public class Gun
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int WarehousesId { get; set; }
        public int InStock { get; set; }
        
        

    }
}
