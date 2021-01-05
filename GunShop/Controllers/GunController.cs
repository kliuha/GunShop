using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GunShop.Domain.Core;
using GunShop.Domai.Interfaces;
using GunShop.Services.Interfaces;
using GunShop.Models;
using GunShop.Infrastructure.Data;

namespace GunShop.Controllers
{
    public class GunController : Controller
    {
        private IGunRepository repo;
        private IPriceCalculation price;
        private IOrderRepository order;
        public GunController(IGunRepository r, IPriceCalculation p,IOrderRepository o)
        {
            repo = r;
            price = p;
            order = o;
        }
        public ActionResult Index()
        {
            var model = new IndexPageViewModel()
            {

                Guns = repo.GetAllGuns().ToDictionary(x => x.Id)
            };
            return View(model);
        }
        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult GunPage(int Id)
        {
            var model = new IndexPageViewModel()
            {

                _Gun = repo.GetGun(Id)

            };
            model._Gun.Price = price.CalculatePrice(model._Gun);
            return View(model);
        }
      
        public ActionResult BuyGun(BuyModel model)
        {
           
            var order = new Order();
            var rep = new Gun();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.GunId = model.GunId;
            rep.InStock = model.inStock;
            this.order.Create(order);
            Gun gun = repo.GetGun(model.GunId);
            Gun inStock = repo.GetGun(model.inStock);
            repo.UpdateCount(gun,inStock);
            return RedirectToAction("Index", "Gun");
        }

    }
}