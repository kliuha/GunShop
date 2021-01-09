using GunShop.Domai.Interfaces;
using GunShop.Domain.Core;
using GunShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Infrastructure.Bussiness
{
    public class ReservationService : IReservationService
    {
        IReservationRepository _resRepo;

        public ReservationService(IReservationRepository resRepo)
        {
            _resRepo = resRepo;
        }


        public Reservation Reserve(Gun gun)
        {
            if (GunIsOccupied(gun))
                throw new InvalidOperationException(String.Format("gun {0} can't be reserved because it is currently occupied", gun.Id));

            var createIt = new Reservation()
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddMinutes(5),
                GunId = gun.Id,
            };

            _resRepo.Create(createIt);

            return createIt;
        }

        public void RemoveReservation(Reservation reservation)
        {
            reservation.End = DateTime.Now;
            _resRepo.Update(reservation);
        }

        public bool IsActive(Reservation reservation)
        {
            return reservation.OrderId.HasValue || reservation.Start < DateTime.Now && reservation.End > DateTime.Now;
        }

        public bool GunIsOccupied(Gun gun)
        {
            var reservationsForCurrentPlace = _resRepo.GetAllForGun(gun.Id);
            if (reservationsForCurrentPlace == null)
                return false;

            var activeReservationFound = false;
            foreach (var res in reservationsForCurrentPlace)
            {
                if (IsActive(res))
                {
                    activeReservationFound = true;
                }
            }

            return activeReservationFound;
        }
    }
}
