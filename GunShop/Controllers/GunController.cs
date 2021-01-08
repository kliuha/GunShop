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
        private IReservationService resserv;
        private IReservationRepository resrepo;
        public GunController(IGunRepository r, IPriceCalculation p,IOrderRepository o,IReservationService rs,IReservationRepository rr)
        {
            repo = r;
            price = p;
            order = o;
            resserv = rs;
            resrepo = rr;
        }
        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            var ggun = repo.GetAllGuns();
            var model = new IndexPageViewModel()
            {

                Guns = repo.GetAllGuns().ToDictionary(x => x.Id),
                ReservedGuns = ggun.Where(p => resserv.GunIsOccupied(p)).Select(p => p.Id).ToList()
            };
            return View(model);
        }
       public ActionResult ReserveGun(int gunId)
        {
            var ggun = repo.GetGun(gunId);
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
            var ggun = repo.GetGun(Id);
            var parameters = new PriceCalculationParameters()
            {
                gun = ggun,
                Tracer = Tracer,
                Hollowpoint = Hollowpoint,
                Incendiary = Incendiary
            };
            var model = new IndexPageViewModel()
            {

                _Gun = repo.GetGun(Id),
                PriceComponents = price.CalculatePrice(parameters)
            };
            var order = new Order();
            order.FirstName = firstName;
            order.LastName = lastName;
            order.GunId = Id;
            this.order.Create(order);
            Gun gun = repo.GetGun(Id);
            repo.UpdateCount(gun);
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