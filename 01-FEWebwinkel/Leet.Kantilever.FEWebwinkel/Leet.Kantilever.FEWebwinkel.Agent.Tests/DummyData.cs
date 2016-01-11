using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using minorcase3pcswinkelen.v1.messages;
using minorcase3pcswinkelen.v1.schema;
using BSCatalogusBeheer = schemaswwwkantilevernl.bscatalogusbeheer.product.v1;

namespace Leet.Kantilever.FEWebwinkel.Agent.Tests
{
    /// <summary>
    /// This class provides dummy data for test purposes
    /// </summary>
    public static class DummyData
    {

        /// <summary>
        /// Dummy data for MsgFindProductsResult 
        /// </summary>
        /// <returns>Dummy MsgFindProductsResult</returns>
        public static MsgFindProductsResult GetMsgFindProductsResult()
        {
            return new MsgFindProductsResult
            {
                Page = 1,
                PageCount = 1,
                PageSize = 10,
                Products = GetProductCollection(),
                Succes = true,
            };
        }

        /// <summary>
        /// Dummy data for WinkelmandResponseMessage 
        /// </summary>
        /// <returns>Dummy WinkelmandResponseMessage</returns>
        public static WinkelmandResponseMessage GetWinkelmandResponseMessage()
        {
            Winkelmand winkelmand = new Winkelmand();
            winkelmand.Add(new WinkelmandRegel
            {
                Aantal = 1,
                Product = new BSCatalogusBeheer.Product
                {
                    Id = 1,
                    Naam = "HL Road Frame - Black, 58",
                    LeverancierNaam = "Koga Miyata",
                    AfbeeldingURL = "no_image_available_small.gif",
                    Prijs = 1431.50M,
                }
            });

            return new WinkelmandResponseMessage
            {
                Winkelmand = winkelmand,
            };
        }

        /// <summary>
        /// Dummy data for ProductCollection 
        /// </summary>
        /// <returns>Dummy ProductCollection</returns>
        public static ProductCollection GetProductCollection()
        {
            return new ProductCollection()
                {
                    new Product
                    {
                        Id = 1,
                        Naam = "HL Road Frame - Black, 58",
                        LeverancierNaam = "Koga Miyata",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 1431.50M,
                    },
                    new Product
                    {
                        Id = 2,
                        Naam = "HL Road Frame - Red, 58",
                        LeverancierNaam = "Eddy Merckx",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 1431.50M,
                    },
                    new Product
                    {
                        Id = 3,
                        Naam = "Sport-100 Helmet, Red",
                        LeverancierNaam = "Batavus",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 34.99M,
                    },
                    new Product
                    {
                        Id = 4,
                        Naam = "Sport-100 Helmet, Black",
                        LeverancierNaam = "Union",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 34.99M,
                    },
                    new Product
                    {
                        Id = 5,
                        Naam = "Mountain Bike Socks, M",
                        LeverancierNaam = "Bikkel",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 9.50M,
                    },
                };
        }
    }
}
