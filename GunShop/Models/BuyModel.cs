using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.Models
{
    public class BuyModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GunId { get; set; }
        public int inStock { get; set; }
        public bool Tracer { get; set; }
        public bool Hollowpoint { get; set; }
        public bool Incendiary { get; set; }
    }
}
