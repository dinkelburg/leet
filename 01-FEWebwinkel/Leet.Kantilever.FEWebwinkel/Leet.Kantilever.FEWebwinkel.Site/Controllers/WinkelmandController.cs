using Leet.Kantilever.FEWebwinkel.Site.Models;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Leet.Kantilever.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
        // GET: Winkelmand
        public ActionResult Index()
        {
            var winkelmandCookie = HttpContext.Request.Cookies.Get("kantileet_winkelmand");
            var viewModel = DeserializeCookie(winkelmandCookie.Value);
        
            return View(viewModel);
        }

        private WinkelmandVM DeserializeCookie(string cookieValue)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var model = serializer.Deserialize<WinkelmandModel>(cookieValue);
            var viewModel = new WinkelmandVM();

            //TODO: validatie voor model. 
            //TODO: model omzetten naar ViewModel

            return viewModel;
        }
    }
}