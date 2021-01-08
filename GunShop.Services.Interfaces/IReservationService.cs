using GunShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation Reserve(Gun gun);
        void RemoveReservation(Reservation reservation);
        bool GunIsOccupied(Gun gun);
        bool IsActive(Reservation reservation);
    }
}
