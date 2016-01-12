using System.Web.Mvc;

namespace Leet.Kantilever.FEWebwinkel.Site.Attributes
{
    public class KantileverAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var requestURL = filterContext.HttpContext.Request.Url;
            filterContext.Result = new RedirectResult($"/Login?ReturnURL={requestURL}");
        }
    }
}