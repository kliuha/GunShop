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
        private IOrderService serv;
        public GunController(IGunRepository r, IPriceCalculation p, IOrderRepository o,IOrderService s)
        {
            repo = r;
            price = p;
            order = o;
            serv = s;
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

      
        public ActionResult GunPage(int Id )
       {
            
            var ggun = repo.GetGun(Id);
            var parameters = new PriceCalculationParameters()
            {
                
                gun = ggun
            };
            var model = new IndexPageViewModel()
            {

                _Gun = repo.GetGun(Id),
                
                PriceComponents = price.CalculatePrices(parameters)
            };
           
                return View(model);
       }
        //public ActionResult Order(int Id)
        //{
        //    var orderr = order.Get(Id);
        //    var gun = repo.GetGun(orderr.GunId);
        //    var ordertWM = new OrderViewModel();
        //    ordertWM.Order = orderr;
        //    ordertWM.Gun = gun;                   
        //    return View();
        //}

        public ActionResult BuyGun(BuyModel model)
        {
           
            var order = new Order();
            var rep = new Gun();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.GunId = model.GunId;          
            rep.InStock = model.inStock;
            this.order.Create(order);
            Gun ggun = repo.GetGun(model.GunId);
            //var parameters = new PriceCalculationParameters()
            //{
            //    Tracer = model.Tracer,
            //    Hollowpoint = model.Hollowpoint,
            //    Incendiary = model.Incendiary,
            //    gun = ggun
            //};
            //var ord = serv.CreateOrder(model.OrderId,
            //                                  model.FirstName,
            //                                  model.LastName,
            //                                  parameters);
            repo.UpdateCount(ggun);
            
            return RedirectToAction("Index","Gun");
        }

    }
}