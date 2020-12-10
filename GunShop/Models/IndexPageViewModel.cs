﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GunShop.Infrastructure.Data;
using GunShop.Domain.Core;


namespace GunShop.Models
{
    public class IndexPageViewModel
    {
        public List<Gun> Gun { get; set; }
        public Dictionary<int,Gun > Guns { get; set; }
    }
}