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

        // GET: Bestelling
        public ActionResult Index()
        {
            var bestellingen = Mapper.MapBestellingToVMList(_agent.FindAllBestellingen());
            return View(bestellingen);
        }

        public ActionResult ToonFactuur(int bestellingID)
        {
            var factuur = Mapper.BestellingToFactuurVM(_agent.FindBestellingByID(bestellingID));
            return View(factuur);
        }
    }
}