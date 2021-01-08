using GunShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.Models
{
    public class OrderViewModel
    {
        public Gun Gun { get; set; }
        public Order Order { get; set; }
        
    }
}