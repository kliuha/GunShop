﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Domain.Core;

namespace GunShop.Services.Interfaces
{
    public interface IOrder
    {
        void MakeOrder(Gun gun);
    }
}
