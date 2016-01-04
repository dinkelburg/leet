using System.Web;
using System.Web.Mvc;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
