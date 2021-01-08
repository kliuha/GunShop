using GunShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Domai.Interfaces
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        Reservation Get(int id);
        List<Reservation> GetAllForGun(int gunId);    
    }
}
