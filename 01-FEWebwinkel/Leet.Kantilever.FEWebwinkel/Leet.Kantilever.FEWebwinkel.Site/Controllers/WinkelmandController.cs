using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
        public HttpStatusCodeResult VoegProductToe(int ProductId, int Aantal)
        {
            // Call naar backend


        
            return new HttpStatusCodeResult(204);
        }
    }
}