using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Domain.Core;

namespace GunShop.Domai.Interfaces
{
    public interface IGunRepository
    {
        List<Gun> GetAllGuns();
        Gun GetGun(int id);
        void Create(Gun gun);
        void Remove(Gun gun);
        List<Gun> SelectionByWarehouse(int id);
    }
}
