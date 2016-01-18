using Leet.Kantilever.FEBestellingen.Agent;
using minorcase3pcsbestellen.v1.schema;
using System.Linq;
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
            bestelling.Ingepakt = true;
            _agent.UpdateBestelling(bestelling);
            return RedirectToAction("ToonFactuur", new { bestelnummer = bestelnummer } );
        }

        // GET: Bestelling
        public ActionResult Index()
        {
            var bestellingen = Mapper.MapBestellingToVMList(_agent.FindAllBestellingen());
            return View(bestellingen);
        }

        /// <summary>
        /// Get next bestelling to be packaged
        /// </summary>
        /// <returns></returns>
        public ActionResult VolgendeBestelling()
        {
            var bestelling = Mapper.MapBestellingToVMList(_agent.FindVolgendeOpenBestelling());
            return View(bestelling);
        }


        /// <summary>
        /// Show factuur information for a specific bestelling
        /// </summary>
        /// <param name="bestelnummer"></param>
        /// <returns></returns>
        public ActionResult ToonFactuur(long bestelnummer)
        {
            var factuur = Mapper.BestellingToFactuurVM(_agent.FindBestellingByBestelnummer(bestelnummer));
            return View(factuur);
        }
    }
}