using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public static class Util
    {
        public static string AfbeeldingPrefix
        {
            get
            {
                return HostingEnvironment.MapPath("~/Resources/Product/");
            }
        }
    }
}