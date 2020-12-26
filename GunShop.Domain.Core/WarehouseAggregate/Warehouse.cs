﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; }

        public List<Gun> Guns { get; set; }

    }
}
