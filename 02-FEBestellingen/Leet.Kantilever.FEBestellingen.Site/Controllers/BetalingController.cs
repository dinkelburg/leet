using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using Leet.Kantilever.FEBestellingen.Agent;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using PcSBestellen = minorcase3pcsbestellen.v1.schema;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
    //[Authorize(Users = @"Pim-Verheij\pim")]
    public class BetalingController : Controller
    {
        private IAgentPcSBestellen _agentPcSBestellen;

        /// <summary>
        /// A constructor that instantiates the IAgentPcSBestellen
        /// </summary>
        public BetalingController()
        {
            _agentPcSBestellen = new AgentPcSBestellen();
        }

        /// <summary>
        /// A constructor that allows to inject IAgentPcSBestellen.
        /// </summary>
        /// <param name="agentPcSBestellen">IAgentPcSBestellen to inject</param>
        public BetalingController(IAgentPcSBestellen agentPcSBestellen)
        {
            _agentPcSBestellen = agentPcSBestellen;
        }

        /// <summary>
        /// Show form to search invoice on bestelnummer
        /// </summary>
        /// <returns>Form to search the invoice</returns>
        public ActionResult ZoekFactuurOpBestelnummer()
        {
            return View();
        }

        /// <summary>
        /// Search invoice on bestelnummer
        /// </summary>
        /// <param name="bestelnummer">Bestelnummer that matches the invoice</param>
        /// <returns>View to show the invoice</returns>
        [HttpPost]
        public ActionResult ZoekFactuurOpBestelnummer(long bestelnummer)
        {
            if (bestelnummer >= 1)
            {
                PcSBestellen.Bestelling bestelling = null;
                try
                {
                    bestelling = _agentPcSBestellen.FindBestellingByBestelnummer(bestelnummer);
                    Bestellingsstatus bestellingStatus = (Bestellingsstatus)bestelling.Status;
                    if ((bestellingStatus & Bestellingsstatus.Geweigerd) > 0 || (bestellingStatus & Bestellingsstatus.Betaald) > 0)
                    {
                        ModelState.AddModelError("bestelnummer", $"De factuur met het bestelnummer {bestelnummer} heeft niet de juiste status om goedgekeurd te kunnen worden.");
                        return View();
                    }

                    var factuur = Mapper.BestellingToFactuurVM(bestelling);
                    return View("Factuur", factuur);
                }
                catch (FaultException)
                {
                    ModelState.AddModelError("bestelnummer", $"De factuur met het bestelnummer {bestelnummer} is niet gevonden in het systeem");
                }
            }
            else
            {
                ModelState.AddModelError("bestelnummer", $"Het bestelnummer moet minimaal 1 zijn");
            }

            return View();
        }

        /// <summary>
        /// Register payment of the invoice
        /// </summary>
        /// <param name="bestelnummer">Bestelnumer of the invoice</param>
        /// <returns>View with the result</returns>
        public ActionResult RegistreerBetaling(long bestelnummer)
        {
            var bestelling = _agentPcSBestellen.FindBestellingByBestelnummer(bestelnummer);
            bestelling.SetStatus(Bestellingsstatus.Betaald);

            _agentPcSBestellen.UpdateBestelling(bestelling);

            return View(bestelnummer);
        }










        public ActionResult ShowListOfNieuweBestellingen()
        {
            var bestellingen = _agentPcSBestellen.FindAllNewBestellingen();

            var bestellingenVM = bestellingen.Select(b => new BestellingListVM
            {
                Bestelnummer = b.Bestelnummer,
                TotaalPrijs = b.BestellingsregelCollection.Sum(br => br.Product.Prijs * br.Aantal).Value,
                AantalProducten = b.BestellingsregelCollection.Sum(br => br.Aantal),
            });

            return View(bestellingenVM);
        }

        public ActionResult GetBestellingOpBestelnummer(long bestelnummer)
        {

            PcSBestellen.Bestelling bestelling = null;
            try
            {
                bestelling = _agentPcSBestellen.FindBestellingByBestelnummer(bestelnummer);
                Bestellingsstatus bestellingStatus = (Bestellingsstatus)bestelling.Status;
                if ((bestellingStatus & Bestellingsstatus.Nieuw) > 0)
                {
                    var factuur = Mapper.BestellingToFactuurVM(bestelling);
                    return View("Factuur_BestellingGoedkeuren", factuur);
                }
            }
            catch (FaultException)
            {
            }

            return View("ShowListOfNieuweBestellingen");
        }

        /// <summary>
        /// Show form to search bestelling on bestelnummer
        /// </summary>
        /// <returns>Form to search the bestelling</returns>
        public ActionResult BestellingGoedkeuren(long bestelnummer)
        {
            var bestelling = _agentPcSBestellen.FindBestellingByBestelnummer(bestelnummer);
            bestelling.SetStatus(Bestellingsstatus.Goedgekeurd);

            _agentPcSBestellen.UpdateBestelling(bestelling);
            return View(bestelnummer);
        }

    }
}