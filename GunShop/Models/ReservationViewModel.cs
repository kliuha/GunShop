using GunShop.Domain.Core;
using GunShop.Domain.Core.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.Models
{
    public class ReservationViewModel
    {
        public DateTime Date { get; set; }       
        public Reservation Reservation { get; set; }
        public Gun gun { get; set; }
        public List<PriceComponent> PriceComponents { get; set; }
    }
}