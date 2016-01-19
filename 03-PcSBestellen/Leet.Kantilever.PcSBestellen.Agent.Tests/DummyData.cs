using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using Leet.Kantilever.BSKlantbeheer.V1.Messages;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using System;
using System.Collections.Generic;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    /// <summary>
    /// This class provides dummy data for test purposes
    /// </summary>
    public class DummyData
    {

        /// <summary>
        /// Dummy data for MsgFindProductByIdResult 
        /// </summary>
        /// <returns>Dummy MsgFindProductByIdResult</returns>
        public static MsgFindProductByIdResult GetMsgFindProductByIdResult()
        {
            return new MsgFindProductByIdResult
            {
                Product = GetProduct(),
                Succes = true,
            };
        }

        /// <summary>
        /// Dummy data for Product 
        /// </summary>
        /// <returns>Dummy Product</returns>
        public static Product GetProduct()
        {
            return new Product
            {
                Id = 1,
                Naam = "HL Road Frame - Black, 58",
                LeverancierNaam = "Koga Miyata",
                AfbeeldingURL = "no_image_available_small.gif",
                Prijs = 1431.50M,
                Beschrijving = "beschrijving",
                LeveranciersProductId = "AFSE34D",
                LeverbaarTot = new DateTime(2017, 3, 12),
                LeverbaarVanaf = new DateTime(2015, 1, 7),

            };
        }

        internal static GetKlantByKlantnummerResponseMessage GetGetKlantByKlantnummerResponseMessage()
        {
            return new GetKlantByKlantnummerResponseMessage
            {
                Klant = new Klant
                {
                    Achternaam = "Vries",
                    Adresregel1 = "Boze Wilg 33",
                    Email = "jdv@worldonline.net",
                    Gebruikersnaam = "jdv",
                    ID = 12464,
                    Klantnummer = "1552fc72-2d19-44e5-ad06-efe175cb51fd",
                    Postcode = "8421CC",
                    Telefoonnummer = "0564875123",
                    Tussenvoegsel = "de",
                    Voornaam = "Jan",
                    Woonplaats = "Den Dolder",
                }
            };
        }



        /// <summary>
        /// Dummy data for list of Producten
        /// </summary>
        public static IEnumerable<Product> Producten
        {
            get
            {
                return new List<Product> {
                    new Product
                    {
                        Id = 1,
                        Naam = "HL Road Frame - Black, 58",
                        LeverancierNaam = "Koga Miyata",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 1431.50M,
                        Beschrijving = "beschrijving",
                        LeveranciersProductId = "AFSE34D",
                        LeverbaarTot = new DateTime(2017, 3, 12),
                        LeverbaarVanaf = new DateTime(2015, 1, 7),
                    },
                    new Product
                    {
                        Id = 2,
                        Naam = "Cliche stadsfiets",
                        LeverancierNaam = "Batavus",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 150M,
                        Beschrijving = "13 in een dozijn apparaat van Batavus",
                        LeveranciersProductId = "BAT12345",
                        LeverbaarTot = new DateTime(2050, 31, 12),
                        LeverbaarVanaf = new DateTime(1920, 1, 1),
                    },
                    new Product
                    {
                        Id = 3,
                        Naam = "Tandem",
                        LeverancierNaam = "Gazelle",
                        AfbeeldingURL = "no_image_available_small.gif",
                        Prijs = 1431.50M,
                        Beschrijving = "Degelijke tandem, weinig speciaals",
                        LeveranciersProductId = "A1B2C3",
                        LeverbaarTot = new DateTime(2017, 3, 12),
                        LeverbaarVanaf = new DateTime(2015, 1, 7),
                    },

                };
            }
        }
    }
}