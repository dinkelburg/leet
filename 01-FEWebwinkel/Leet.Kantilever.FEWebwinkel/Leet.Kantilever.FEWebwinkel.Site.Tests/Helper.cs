using Leet.Kantilever.FEWebwinkel.Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests
{
    public static class Helper
    {
        /// <summary>
        /// Helper method to create a controllercontext
        /// </summary>
        /// <param name="controller">The controller self</param>
        /// <returns>ControllerContext</returns>
        public static ControllerContext CreateContext(Controller controller)
        {
            var request = new HttpRequest("", "http://example.com/", "");
            var response = new HttpResponse(TextWriter.Null);
            var httpContext = new HttpContextWrapper(new HttpContext(request, response));
            return new ControllerContext(httpContext, new RouteData(), controller);
        }

        /// <summary>
        /// Helper method to set a new cookie
        /// </summary>
        /// <param name="name">Name of the cookie</param>
        /// <param name="controller">Controller to set the cookie</param>
        public static void SetCookie(string name, Controller controller)
        {
            var serializer = new JavaScriptSerializer();

            switch (name)
            {
                case "winkelmandjeInhoud":
                    var winkelmandinhoudCookie = new HttpCookie("kantileet_winkelmand", serializer.Serialize(CreateWinkelmandCookie()));
                    controller.HttpContext.Request.Cookies.Add(winkelmandinhoudCookie);
                    break;
            }
        }

        private static List<WinkelmandModel> CreateWinkelmandCookie()
        {
            return new List<WinkelmandModel>
            {
                    new WinkelmandModel {
                        ProductId = "123",
                        Aantal = 5
                    },
                    new WinkelmandModel {
                        ProductId = "456",
                        Aantal = 2
                    },
                    new WinkelmandModel {
                        ProductId = "789",
                        Aantal = 3
                    },
            };
        }
    }
}
