using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Domain.Core;
using GunShop.Domai.Interfaces;
using GunShop.Services.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace GunShop.Infrastructure.Data
{
    public class GunRepository : IGunRepository
    {
        private OrderContext db;
        public GunRepository()
        {
            this.db = new OrderContext();
        }
        public List<Gun> GetAllGuns()
        {
            return db.Guns.ToList();
        }
        
        public Gun GetGun(int gunId)
        {
            return db.Guns.Find(gunId);
        }
        public void Create(Gun gun)
        {
            db.Guns.Add(gun);
        }
       
    }
}
