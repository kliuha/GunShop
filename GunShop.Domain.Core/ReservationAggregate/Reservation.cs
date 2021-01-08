using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domain.Core
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int GunId { get; set; }
        public int? OrderId { get; set; }
    }
}
