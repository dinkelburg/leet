using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEWebwinkel.Agent.Tests
{
    public static class DummyData
    {
        public static MsgFindProductsResult GetMsgFindProductsResult()
        {
            return new MsgFindProductsResult
            {
                Page = 1,
                PageCount = 1,
                PageSize = 10,
                Products = new ProductCollection()
                {
                    new Product
                    {
                        Id = 1,
                        Naam = "HL Road Frame - Black, 58",
                        LeverancierNaam = "Gazelle",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 1431.50M,
                    },
                },
                Succes = true,
            };
        }
    }
}
