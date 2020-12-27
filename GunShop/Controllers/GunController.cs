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
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.GunId = model.GunId;
            this.order.Create(order);
            Gun gun = repo.GetGun(model.GunId);
            //price.CalculatePrice(gun);
            repo.Remove(gun);
            return RedirectToAction("Index", "Gun");
        }
       
       
    }
}