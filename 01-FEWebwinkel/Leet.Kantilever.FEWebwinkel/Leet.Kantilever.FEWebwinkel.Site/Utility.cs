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

        /// <summary>
        /// Checks if the client already has a clientID cookie set. If this is not the
        /// case, a new clientID cookie is set.
        /// </summary>
        /// <param name="request">The request containing the cookie.</param>
        /// <param name="response">The response containing the cookie.</param>
        /// <returns></returns>
        public static string CheckClientID(HttpRequestBase request, HttpResponseBase response)
        {
            if(request == null)
            {
                throw new ArgumentNullException("request", "The request object was null.");
            }

            if (response == null)
            {
                throw new ArgumentNullException("response", "The response object was null.");
            }

            var clientIDCookie = request.Cookies.Get("clientId");
            string clientId;

            if (clientIDCookie == null)
            {
                clientId = Guid.NewGuid().ToString();
                response.Cookies.Add(new HttpCookie("clientId", clientId));
            }
            else
            {
                clientId = clientIDCookie.Value;
            }
            return clientId;
        }
    }
}