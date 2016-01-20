using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using Leet.Kantilever.FEBestellingen.Agent;
using System.ServiceModel;
using System.Web.Mvc;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
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
        public ActionResult ZoekOpBestelnummer()
        {
            return View();
        }

        /// <summary>
        /// Search invoice on bestelnummer
        /// </summary>
        /// <param name="bestelnummer">Bestelnummer that matches the invoice</param>
        /// <returns>View to show the invoice</returns>
        [HttpPost]
        public ActionResult ZoekOpBestelnummer(long bestelnummer)
        {
            if (bestelnummer >= 1)
            {
                minorcase3pcsbestellen.v1.schema.Bestelling bestelling = null;
                try
                {
                    bestelling = _agentPcSBestellen.FindBestellingByBestelnummer(bestelnummer);
                    BestellingStatus bestellingStatus = (BestellingStatus)bestelling.Status;
                    if ((bestellingStatus & BestellingStatus.Geweigerd) > 0 || (bestellingStatus & BestellingStatus.Betaald) > 0)
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
                ModelState.AddModelError("bestelnummer", $"Het bestelnummer moet een positief getal zijn");
            }

            return View();
        }

        /// <summary>
        /// Register payment of the invoice
        /// </summary>
        /// <param name="bestelnummer">Bestelnumer of the invoice</param>
        /// <returns>View with the result</returns>
        public ActionResult RegistreerBetaling (long bestelnummer)
        {
            var bestelling = _agentPcSBestellen.FindBestellingByBestelnummer(bestelnummer);

            BestellingStatus bestellingStatus = (BestellingStatus)bestelling.Status;
            bestellingStatus = bestellingStatus | BestellingStatus.Betaald;

            bestelling.Status = (int)bestellingStatus;

            _agentPcSBestellen.UpdateBestelling(bestelling);

            return View(bestelnummer);
        }
    }
}