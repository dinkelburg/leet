using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using Minor.Case3.BsKlantbeheer.V1.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class BestellenController : Controller
    {
        private IAgentPcSWinkelen _winkelAgent;
        private IAgentPcSBestellen _bestellenAgent;

        /// <summary>
        /// A constructor that instantiates the IAgentPcSWinkelen and IAgentPcSBestellen
        /// </summary>
        public BestellenController()
        {
            _winkelAgent = new AgentPcSWinkelen();
            _bestellenAgent = new AgentPcSBestellen();
        }

        /// <summary>
        /// A constructor that allows inject different IAgentPcSWinkelen and IAgentPcSBestellen objects.
        /// </summary>
        /// <param name="winkelAgent">IAgentPcSWinkelen to inject</param>
        /// <param name="bestellenAgent">IAgentPcSBestellen to inject</param>
        public BestellenController(IAgentPcSWinkelen winkelAgent, IAgentPcSBestellen bestellenAgent)
        {
            _winkelAgent = winkelAgent;
            _bestellenAgent = bestellenAgent;
        }

        /// <summary>
        /// Shows the from to insert Klantgegevens
        /// </summary>
        /// <returns></returns>
        public ActionResult GegevensInvoeren()
        {
            string clientID = Utility.CheckClientID(Request, Response);

            var winkelmand = _winkelAgent.GetWinkelmand(clientID);
            ViewBag.CountProduct = winkelmand.Sum(p => p.Aantal);

            return View();
        }

        /// <summary>
        /// Post to persists Klantgegevens
        /// Calling an agent to save the Klantgegevens into an other service
        /// </summary>
        /// <param name="klantVM">Klantgegevens viewmodel</param>
        /// <returns>Redirect to action ThankYouPage</returns>
        [HttpPost]
        public ActionResult GegevensInvoeren(KlantVM klantVM)
        {
            if (ModelState.IsValid)
            {
                string clientID = Utility.CheckClientID(Request, Response);

                var winkelmand = _winkelAgent.GetWinkelmand(clientID);
                ViewBag.CountProduct = winkelmand.Sum(p => p.Aantal);

                AutoMapper.Mapper.CreateMap<KlantVM, Klant>();
                var klant = AutoMapper.Mapper.Map<Klant>(klantVM);
                klant.Klantnummer = clientID;
                _bestellenAgent.CreateBestelling(klant);

                return RedirectToRoute("ThankYou");
            }
            else
            {
                return View(klantVM);
            }
        }

        /// <summary>
        /// Shows the thank you page for Bestellen
        /// </summary>
        /// <returns>View</returns>
        public ActionResult ThankYouPage()
        {
            string clientID = Utility.CheckClientID(Request, Response);
            var winkelmand = _winkelAgent.GetWinkelmand(clientID);
            ViewBag.CountProduct = winkelmand.Sum(p => p.Aantal);
            return View();
        }
    }
}