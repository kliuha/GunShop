using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GunShop.Domain.Core;
using GunShop.Domai.Interfaces;
using GunShop.Services.Interfaces;
using GunShop.Models;

namespace GunShop.Controllers
{
    public class WarehouseController : Controller
    {
        private  IGunRepository repo;
        private IPriceCalculation price;
        private IOrderRepository order;
        private IWarehouseRepository ware;
        public WarehouseController(IGunRepository r, IPriceCalculation p, IOrderRepository o,IWarehouseRepository w)
        {
            repo = r;
            price = p;
            order = o;
            ware = w;
        }
        public ActionResult Warehouses()
        {
            var model = new IndexPageViewModel()
            {

                Ware = ware.GetAllWarehouses().ToDictionary(x => x.Id)
            };
            return View(model);

        }
            public ActionResult WarehouseGuns(int Id)
        {
            var model = new IndexPageViewModel()
            {

                Gun = repo.SelectionByWarehouse(Id)

            };           
            return View(model);
        }
        public ActionResult GunPage(int id)
        {
            return RedirectToAction("GunPage", "Gun", new { id = id });
        }
        
        
    }
}