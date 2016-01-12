using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public static class Utility
    {
        public static string BaseUrl
        {
            get
            {
                var request = HttpContext.Current.Request;
                return request.Url.Scheme + "://" + request.Url.Authority +
                                        request.ApplicationPath.TrimEnd('/') + "/";
            }
        }

        public static string AfbeeldingPrefix
        {
            get
            {
                return BaseUrl + "Resources/Product/";
            }
        }
    }
}