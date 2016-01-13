using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minorcase3pcswinkelen.v1.schema;
using Minor.Case3.BsKlantbeheer.V1.Schema;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;

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
                Products = GetProductCollection(),
                Succes = true,
            };
        }

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

        /// <summary>
        /// Dummy data for KlantVM
        /// </summary>
        /// <returns>Dummy KlantVM</returns>
        public static KlantVM GetKlantVM()
        {
            return new KlantVM
            {
                ID = 111,
                Voornaam = "Kees",
                Achternaam = "Kantilever",
                Adresregel1 = "Kantileverstraat 11",
                Email = "kees@kantilever.nl",
                Gebruikersnaam = "KeesKantilever",
                Postcode = "3928HH",
                Telefoonnummer = "0612345678",
                Woonplaats = "Utrecht",
            };
        }


        /// <summary>
        /// Dummy data for a Winkelmand
        /// </summary>
        /// <returns>Dummy Winkelmand</returns>
        public static Winkelmand GetWinkelmand()
        {
            var winkelmand = new Winkelmand();
            winkelmand.Add(new WinkelmandRegel
            {
                Aantal = 10,
                Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                {
                    Id = 5,
                    Naam = "Mountain Bike Socks, M",
                    LeverancierNaam = "Bikkel",
                    AfbeeldingURL = "no_image_available_small.gif",
                    Prijs = 9.50M,
                },
            });

            return winkelmand;
        }
    }
}
