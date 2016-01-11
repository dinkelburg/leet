using Kantilever.BsCatalogusbeheer.Product.V1;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leet.Kantilever.FEWebwinkel.Site
{
    public static class Mapper
    {
        public static IEnumerable<ProductVM> MapToProductVMList(ProductCollection productCollection)
        {
            return productCollection.Select(product => new ProductVM
            {
                ID = product.Id,
                Naam = product.Naam,
                LeverancierNaam = product.LeverancierNaam,
                Prijs = product.Prijs,
                AfbeeldingPad = Utility.AfbeeldingPrefix + product.AfbeeldingURL,
            });
        }
    }
}