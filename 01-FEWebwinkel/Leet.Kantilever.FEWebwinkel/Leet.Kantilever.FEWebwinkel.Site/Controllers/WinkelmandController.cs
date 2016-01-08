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
        private IWinkelenService _winkelAgent;

        public WinkelmandController()
        {

        }

        public WinkelmandController(IWinkelenService winkelAgent)
        {
            _winkelAgent = winkelAgent;
        }

        // GET: Winkelmand
        public ActionResult Index()
        {
            var clientIdCookie = Request.Cookies.Get("clientId");
            string clientIdString;

            if (clientIdCookie == null)
            {
                clientIdString = Guid.NewGuid().ToString();
                Response.Cookies.Add(new HttpCookie("clientId", clientIdString));

                //if there was no clientId cookie present, a new one is made,
                //and go to the empty basket page right away. 
                return View("LegeWinkelmand");
            }
            else
            {
                clientIdString = clientIdCookie.Value;
            }

            var requestMessage = new VraagWinkelmandRequestMessage
            {
                ClientID = clientIdString
            };

            var winkelmand = _winkelAgent.GetWinkelmandje(requestMessage);
            var winkelmandVM = CreateWinkelmandVM(winkelmand);

            return View(winkelmandVM);
        }



        public ActionResult VoegProductToe(int artikelId, int aantal)
        {
            var clientIdCookie = Request.Cookies.Get("clientId");
            string clientIdString;

            if (clientIdCookie == null)
            {
                // If no clientId cookie was found, make a new cookie.
                clientIdString = Guid.NewGuid().ToString();
                Response.Cookies.Add(new HttpCookie("clientId", clientIdString));
            }
            else
            {
                clientIdString = clientIdCookie.Value;
            }

            var requestMessage = new ToevoegenWinkelmandRequestMessage()
            {
                BestelProduct = new BestelProduct
                {
                    Aantal = aantal,
                    ClientID = clientIdString,
                    ProductID = artikelId
                },
            };

            _winkelAgent.VoegProductToe(requestMessage);

            return new HttpStatusCodeResult(204);
        }


        private static WinkelmandVM CreateWinkelmandVM(WinkelmandResponseMessage message)
        {
            var winkelmand = new WinkelmandVM
            {
                Producten = new List<WinkelmandRijVM>()
            };

            foreach (var item in message.Winkelmand)
            {
                winkelmand.Producten.Add(new WinkelmandRijVM
                {
                    Aantal = item.Aantal,
                    Naam = item.Product.Naam,
                    Prijs = item.Product.Prijs
                });
            }

            return winkelmand;
        }
    }
}