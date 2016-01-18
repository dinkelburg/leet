using System.Web.Mvc;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            //_manager = new BestellingManager();
        }
                
        public ActionResult Index()
        {
            return View();
        }
    }
}