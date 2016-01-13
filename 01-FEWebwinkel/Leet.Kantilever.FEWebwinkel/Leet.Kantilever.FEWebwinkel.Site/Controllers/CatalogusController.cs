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
        private IAgentBSCatalogusBeheer _bsCatalogusAgent;
        private IAgentPcSWinkelen _winkelAgent;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public CatalogusController()
        {
            _bsCatalogusAgent = new AgentBSCatalogusBeheer();
            _winkelAgent = new AgentPcSWinkelen();
        }

        /// <summary>
        /// A constructor that allows injecting a different IAgentBSCatalogusBeheer object.
        /// </summary>
        /// <param name="agent"></param>
        public CatalogusController(IAgentBSCatalogusBeheer bsCatalogusAgent, IAgentPcSWinkelen winkelAgent)
        {
            _bsCatalogusAgent = bsCatalogusAgent;
            _winkelAgent = winkelAgent;
        }

        /// <summary>
        /// Shows a specific page of the catalogus.
        /// </summary>
        /// <param name="page">The page to show.</param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            string clientID = Utility.CheckClientID(Request, Response);

            var products = Mapper.MapToProductVMList(_bsCatalogusAgent.FindProducts(page));

            var winkelmand = _winkelAgent.GetWinkelmand(clientID);
            ViewBag.CountProduct = winkelmand.Sum(p => p.Aantal);

            return View(products);
        }
    }
}