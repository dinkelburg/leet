using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    /// <summary>
    /// Contains various methods used in other classes and views.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Is used to create a correct path to an image.
        /// </summary>
        public static string AfbeeldingPrefix
        {
            get
            {
                return HostingEnvironment.MapPath("~/Resources/Product/");
            }
        }
    }
}