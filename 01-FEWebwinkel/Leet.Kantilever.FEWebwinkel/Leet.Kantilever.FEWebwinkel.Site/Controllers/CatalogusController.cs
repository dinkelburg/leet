using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class CatalogusController : Controller
    {
        private IAgentBSCatalogusBeheer _agent;

        public CatalogusController()
        {
            _agent = new AgentBSCatalogusBeheer();
        }

        public CatalogusController(IAgentBSCatalogusBeheer agent)
        {
            _agent = agent;
        }

        // GET: Catalogus
        public ActionResult Index(int? page)
        {
            WinkelmandController.CheckClientID(Request, Response);

            var products = Mapper.MapToProductVMList(_agent.FindProducts(page));
            return View(products);
        }
    }
}