using GunShop.Domai.Interfaces;
using GunShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop.Infrastructure.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private OrderContext db;
        public ReservationRepository()
        {
            this.db = new OrderContext();
        }       
        public List<Reservation> GetAllForGun(int gunId)
        {
           
                return db.Reservations.Where(x => x.GunId == gunId).ToList();
            
        }
        public void Create(Reservation reservation)
        {
            
                db.Reservations.Add(reservation);
                db.SaveChanges();
            
        }

        public void Update(Reservation reservation)
        {
           
                db.Reservations.Attach(reservation);
                db.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            
        }

        public Reservation Get(int id)
        {
           
                return db.Reservations.FirstOrDefault(p => p.Id == id);
            
        }
    }
}
