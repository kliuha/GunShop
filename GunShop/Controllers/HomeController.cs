﻿using System;
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
    public class HomeController : Controller
    {
        private  IGunRepository repo;
        private IPriceCalculation price;
        public HomeController(IGunRepository r, IPriceCalculation p)
        {
            repo = r;
            price = p;
        }
        public ActionResult Index()
        {
            var model = new IndexPageViewModel()
            {
             
                Guns = repo.GetAllGuns().ToDictionary(x => x.Id)
            };
            return View(model);
        }

        public ActionResult Buy(int id)
        {
            Gun gun = repo.GetGun(id);
            price.CalculatePrice(gun);
            return View();
        }
        //protected override void Dispose(bool disposing)
        //{
        //    repo.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}