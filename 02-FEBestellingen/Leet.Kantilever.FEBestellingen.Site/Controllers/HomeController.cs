using System.Web.Mvc;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
    public class HomeController : Controller
    {
        private IOrderManager _manager;

        public HomeController()
        {
            //_manager = new BestellingManager();
        }

        public HomeController(IOrderManager manager)
        {
            _manager = manager;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        //public ActionResult ViewOrder(int id)
        //{
        //    return View(_manager.GetOrderRegelsForOrder(id));
        //}
    }
}