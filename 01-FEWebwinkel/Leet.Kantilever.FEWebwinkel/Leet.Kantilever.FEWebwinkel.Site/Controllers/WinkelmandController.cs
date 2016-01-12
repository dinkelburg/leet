using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using minorcase3pcswinkelen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
        private IAgentPcSWinkelen _winkelAgent;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public WinkelmandController()
        {
            _winkelAgent = new AgentPcSWinkelen();
        }

        /// <summary>
        /// A constructor that allows injecting a different IAgentPcSWinkelen object.
        /// </summary>
        /// <param name="winkelAgent"></param>
        public WinkelmandController(IAgentPcSWinkelen winkelAgent)
        {
            _winkelAgent = winkelAgent;
        }

        /// <summary>
        /// Shows the contents of the customer's winkelmand.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string clientIdString = Utility.CheckClientID(Request, Response);

            var winkelmand = _winkelAgent.GetWinkelmand(clientIdString);

            if (winkelmand.Count == 0)
            {
                return View("LegeWinkelmand");
            }

            var winkelmandVM = CreateWinkelmandVM(winkelmand);
            ViewBag.CountProduct = winkelmandVM.Producten.Sum(p => p.Aantal);
            return View(winkelmandVM);
        }


        /// <summary>
        /// Adds a product to the winkelmand for the customer to order at a later time. 
        /// Is used in AJAX calls.
        /// </summary>
        /// <param name="productID">The ID of the product to add to the winkelmand</param>
        /// <param name="aantal">The amount of the product to add.</param>
        /// <returns></returns>
        public ActionResult VoegProductToe(int productID, int aantal)
        {
            string clientIdString = Utility.CheckClientID(Request, Response);

            var winkelmand = _winkelAgent.VoegProductToeAanWinkelmand(productID, aantal, clientIdString);

            return Json(new { CountProduct = winkelmand.Sum(p => p.Aantal) }, JsonRequestBehavior.AllowGet);
        }


        private static WinkelmandVM CreateWinkelmandVM(Winkelmand winkelmand)
        {
            var newWinkelmand = new WinkelmandVM
            {
                Producten = new List<WinkelmandRijVM>()
            };

            foreach (var item in winkelmand)
            {
                newWinkelmand.Producten.Add(new WinkelmandRijVM
                {
                    Aantal = item.Aantal,
                    Naam = item.Product.Naam,
                    Prijs = item.Product.Prijs
                });
            }

            return newWinkelmand;
        }

        }
    }
