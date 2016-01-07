﻿using Leet.Kantilever.FEWebwinkel.Site.Models;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
        // GET: Winkelmand
        public ActionResult Index()
        {
            var winkelmand = new WinkelmandVM { Producten = new List<WinkelmandVM.WinkelmandRijVM>
            {
                new WinkelmandVM.WinkelmandRijVM { Naam = "Fiets, blauw", Aantal = 1, Prijs = 299.00M },
                new WinkelmandVM.WinkelmandRijVM { Naam = "Fietsketting", Aantal = 2, Prijs = 30M },
                new WinkelmandVM.WinkelmandRijVM { Naam = "Koplamp, Batavus", Aantal = 5, Prijs = 15M },
                new WinkelmandVM.WinkelmandRijVM { Naam = "Zadel, Comfizit", Aantal = 2, Prijs = 7.95M }, 
            }};

            var clientId = Request.Cookies.Get("clientId");
            if (clientId == null)
            {
                return View("LegeWinkelmand");
            }
            return View(winkelmand);

            //1 PcSWinkelen aanroepen
            //2 clientId.Value aan PcS geven
            //3 ontvang lijst met objecten
            //4 lijst naar view passen
            
        }

        public ActionResult VoegProductToe(string artikelId, int aantal)
        {
            return new HttpStatusCodeResult(200);
        }

        //private WinkelmandVM DeserializeCookie(string cookieValue)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    var model = serializer.Deserialize<WinkelmandModel>(cookieValue);
        //    var viewModel = new WinkelmandVM();

        //    //TODO: validatie voor model. 
        //    //TODO: model omzetten naar ViewModel

        //    return viewModel;
        //}
    }
}