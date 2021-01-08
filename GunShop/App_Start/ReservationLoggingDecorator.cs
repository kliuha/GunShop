using GunShop.Domain.Core;
using GunShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GunShop.App_Start
{
    public class ReservationLoggingDecorator : IReservationService
    {
        public IReservationService _decoratedObject;
        private ILogger _logger;

        public ReservationLoggingDecorator(IReservationService DecoratedObject, ILogger logger)
        {
            _decoratedObject = DecoratedObject;
            _logger = logger;
        }

        public Reservation Reserve(Gun gun)
        {
            try
            {
                var reserve = _decoratedObject.Reserve(gun);
                string message = string.Format("Successfully make a reservation for a gun with Id {0}, type {2} and price {1}.",
                gun.Id, gun.Type, gun.Price);
                _logger.Log(message, LogSeverity.Info);
                return reserve;
            }
            catch (Exception exception)
            {
                string message = string.Format("Attempt to reserve a gun with Id {0}, type {2} and price {1} was failed.",
                gun.Id, gun.Type, gun.Price);
                _logger.Log(message, LogSeverity.Info);

                throw exception;
            }

        }

        public bool IsActive(Reservation reservation)
        {
            return _decoratedObject.IsActive(reservation);
        }

        public bool GunIsOccupied(Gun gun)
        {
            return _decoratedObject.GunIsOccupied(gun);
        }

        public void RemoveReservation(Reservation reservation)
        {
            try
            {
                _decoratedObject.RemoveReservation(reservation);
                string message = string.Format("Successfully remove a reservation for a gun with reservation Id {0} for gun Id {1} with order Id {2}.",
                reservation.Id, reservation.GunId, reservation.OrderId);
                _logger.Log(message, LogSeverity.Info);
            }
            catch (Exception exception)
            {
                string message = string.Format("Attempt to remove a reservation for a gun with reservation Id {0} for gun Id {1} with order Id {2} was failed.",
                reservation.Id, reservation.GunId, reservation.OrderId);
                _logger.Log(message, LogSeverity.Info);

                throw exception;
            }
        }
    }
}