using Leet.Kantilever.FEBestellingen.Agent;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using minorcase3pcsbestellen.v1.schema;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
    public class BestellingController : Controller
    {
        private IAgentPcSBestellen _agent;

        public BestellingController()
        {
            _agent = new AgentPcSBestellen();
        }

        public BestellingController(IAgentPcSBestellen agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// Finish packing bestelling
        /// </summary>
        /// <param name="bestelnummer"></param>
        /// <returns></returns>
        public ActionResult FinishOrder(long bestelnummer)
        {
            var bestelling = _agent.FindBestellingByBestelnummer(bestelnummer);
            bestelling.Status = minorcase3bsbestellingenbeheer.v1.schema.BestellingStatus.Ingepakt;
            _agent.UpdateBestelling(bestelling);
            return RedirectToAction("ToonFactuur", new { bestelnummer = bestelnummer } );
        }

        // GET: Bestelling
        public ActionResult Index()
        {
            BestellingCollection bestellingen = _agent.FindAllBestellingen();
            IEnumerable<BestellingVM> bestellingVM = Mapper.MapBestellingToVMList(bestellingen);
            return View(bestellingVM);
        }

        /// <summary>
        /// Get next bestelling to be packaged
        /// </summary>
        /// <returns></returns>
        public ActionResult VolgendeBestelling()
        {
            BestellingVM bestellingVM = null;
            try
            {
                Bestelling bestelling = _agent.FindVolgendeOpenBestelling();
                bestellingVM = Mapper.MapBestellingToVMList(bestelling);
            }
            catch (FaultException ex)
            {

            }

            return View(bestellingVM);
        }


        /// <summary>
        /// Show factuur information for a specific bestelling
        /// </summary>
        /// <param name="bestelnummer"></param>
        /// <returns></returns>
        public ActionResult ToonFactuur(long bestelnummer)
        {
            Bestelling bestelling = _agent.FindBestellingByBestelnummer(bestelnummer);
            var factuur = Mapper.BestellingToFactuurVM(bestelling);
            return View(factuur);
        }
    }
}