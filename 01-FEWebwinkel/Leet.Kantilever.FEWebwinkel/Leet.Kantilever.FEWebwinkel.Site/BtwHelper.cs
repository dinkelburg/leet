using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public static class BtwHelper
    {
        /// <summary>
        /// Calculates the price for a product with added btw. 
        /// If nothing was entered, return nothing.
        /// </summary>
        /// <param name="originalPrice">The price without btw.</param>
        /// <returns></returns>
        public static decimal? CalculateBtw(decimal? originalPrice)
        {
            if (originalPrice.HasValue)
            {
                return originalPrice / 100 * (100 + GetCurrentBtw());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Returns the currently selected btw rate for products.
        /// </summary>
        /// <returns>A btw rate in decimal format.</returns>
        private static decimal GetCurrentBtw()
        {
            BtwConfigSection tariefSection =
                ConfigurationManager.GetSection("btw/tarieven") as BtwConfigSection;

            var tarieven = tariefSection.Tarieven.OfType<TariefElement>().ToList();

            //High btw rate is currently the default, this needs to be changed in a later
            //sprint to make the btw rate selectable.
            var tarief = tarieven.Where(t => t.Mode == "hoog").Select(t => t.Value).Single();
            return decimal.Parse(tarief);
        }
    }
}