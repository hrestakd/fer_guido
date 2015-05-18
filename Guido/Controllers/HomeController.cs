﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleMapsApi.StaticMaps;
using Baza;
namespace Guido.Controllers
{
    public class HomeController : Controller
    {
        private GuidoEntities db = new GuidoEntities();

        public ActionResult Index()
        {
            dynamic mymodel = new ViewModel();
            mymodel.City = db.City.Include(c => c.State);
            mymodel.Place = db.Place.Include(v => v.City);
            return View(mymodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetRoute(string rt)
        {
            int myRt = Convert.ToInt32(rt);
            double povratni = 0;
            var routes =
                from o in db.RoutePoint
                where o.IdRoute == myRt
                select new
                {
                    longitude = o.Place.longitude,
                    latitude = o.Place.latitude
                };
            foreach (var koord in routes)
            {
                
                povratni = koord.longitude;
            }
            return Content(povratni.ToString());
        }
    }
}