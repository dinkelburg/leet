using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Site.Models;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using minorcase3pcswinkelen.v1.messages;
using minorcase3pcswinkelen.v1.schema;
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
        private IAgentPcSWinkelen _winkelAgent;

        public WinkelmandController()
        {
            _winkelAgent = new AgentPcSWinkelen();
        }

        public WinkelmandController(IAgentPcSWinkelen winkelAgent)
        {
            _winkelAgent = winkelAgent;
        }

        // GET: Winkelmand
        public ActionResult Index()
        {
            string clientIdString = CheckClientID(Request, Response);

            var winkelmand = _winkelAgent.GetWinkelmand(clientIdString);

            if (winkelmand.Count == 0)
            {
                return View("LegeWinkelmand");
            }

            var winkelmandVM = CreateWinkelmandVM(winkelmand);

            return View(winkelmandVM);
        }



        public ActionResult VoegProductToe(int artikelId, int aantal)
        {
            string clientIdString = CheckClientID(Request, Response);

            _winkelAgent.VoegProductToeAanWinkelmand(artikelId, aantal, clientIdString);

            return new HttpStatusCodeResult(204);
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

        public static string CheckClientID(HttpRequestBase request, HttpResponseBase response)
        {
            var clientIDCookie = request.Cookies.Get("clientId");
            string clientId;

            if (clientIDCookie == null)
            {
                clientId = Guid.NewGuid().ToString();
                response.Cookies.Add(new HttpCookie("clientId", clientId));
            }
            else
            {
                clientId = clientIDCookie.Value;
            }
            return clientId;

        }
    }
}