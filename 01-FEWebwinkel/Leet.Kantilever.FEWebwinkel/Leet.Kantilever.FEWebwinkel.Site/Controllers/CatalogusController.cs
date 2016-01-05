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
        // GET: Catalogus
        public ActionResult Index(int? page)
        {
            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer();

            var products = agent.FindAllProducts(page).Select(product => new ProductVM
            {
                ID = product.Id,
                Naam = product.Naam,
                LeverancierNaam = product.LeverancierNaam,
                Prijs = product.Prijs,
                AfbeeldingPad = product.AfbeeldingURL,
            }); ;

            return View(products);
        }
    }
}