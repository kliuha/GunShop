using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunShop.Domain.Core;
namespace GunShop.Domai.Interfaces
{
  public interface IWarehouseRepository
    {
        List<Warehouse> GetAllWarehouses();
    }
}
