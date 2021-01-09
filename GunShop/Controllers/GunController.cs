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
        private IGunRepository gunrepo;
        private IPriceCalculation price;
        private IOrderRepository orderrep;
        private IReservationService resserv;
        private IReservationRepository resrepo;
        public GunController(IGunRepository r, IPriceCalculation p,IOrderRepository o,IReservationService rs,IReservationRepository rr)
        {
            gunrepo = r;
            price = p;
            orderrep = o;
            resserv = rs;
            resrepo = rr;
        }
        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            var ggun = gunrepo.GetAllGuns();
            var model = new IndexPageViewModel()
            {

                Guns = gunrepo.GetAllGuns().ToDictionary(x => x.Id),
                ReservedGuns = ggun.Where(p => resserv.GunIsOccupied(p)).Select(p => p.Id).ToList()
            };
            return View(model);
        }
       public ActionResult ReserveGun(int gunId)
        {
            var ggun = gunrepo.GetGun(gunId);
            var date = DateTime.Now;
            var parameters = new PriceCalculationParameters()
            {
                gun = ggun
            };

            var reservation = resserv.Reserve(ggun);

            var model = new ReservationViewModel()
            {
                Reservation = reservation,
                gun = ggun,
                PriceComponents = price.CalculatePrice(parameters),
                Date = date,              
            };
            return View(model);
        }

        public ActionResult GunPage(int Id,bool Tracer ,bool Hollowpoint,bool Incendiary,string firstName, string lastName,int resId)
        {
            var ggun = gunrepo.GetGun(Id);
            var parameters = new PriceCalculationParameters()
            {
                gun = ggun,
                Tracer = Tracer,
                Hollowpoint = Hollowpoint,
                Incendiary = Incendiary
            };
            var model = new IndexPageViewModel()
            {

                _Gun = gunrepo.GetGun(Id),
                PriceComponents = price.CalculatePrice(parameters)
            };
            var order = new Order();
            order.FirstName = firstName;
            order.LastName = lastName;
            order.GunId = Id;
            this.orderrep.Create(order);
            Gun gun = gunrepo.GetGun(Id);
            gunrepo.UpdateCount(gun);
            Reservation reservation = resrepo.Get(resId);
            resserv.RemoveReservation(reservation);
            return View(model);
        }
      
        public ActionResult BuyGun()
        {
            return RedirectToAction("Index", "Gun");

        }

    }
}