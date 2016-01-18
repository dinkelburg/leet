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

        public ActionResult FinishOrder(long bestelnummer)
        {
            
            return RedirectToAction("ToonFactuur", bestelnummer);
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
        /// <param name="bestellingID"></param>
        /// <returns></returns>
        public ActionResult ToonFactuur(long bestellingID)
        {
            var factuur = Mapper.BestellingToFactuurVM(_agent.FindBestellingByID((int)bestellingID));
            return View(factuur);
        }
    }
}