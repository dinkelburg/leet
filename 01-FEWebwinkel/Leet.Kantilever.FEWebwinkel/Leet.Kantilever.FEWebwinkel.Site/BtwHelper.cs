using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public static class BtwHelper
    {
        public static decimal CalculateBtw(decimal originalPrice)
        {
            return originalPrice * 1.21m;
        }

        private static decimal GetCurrentBtw()
        {
            BtwConfigSection tariefSection =
                ConfigurationManager.GetSection("btw/tarieven") as BtwConfigSection;

            var tarieven = tariefSection.Tarieven.AsQueryable();

            return tarief;
        }
    }
}