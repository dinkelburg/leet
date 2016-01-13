using System;
using minorcase3pcsbestellen.v1.messages;
using minorcase3pcsbestellen.v1.schema;
using schemaswwwkantilevernl.bscatalogusbeheer.product.v1;
using minorcase3bsklantbeheer.v1.schema;

namespace Leet.Kantilever.FEBestellingen.Agent.Tests
{
    class DummyData
    {
        public static BestellingCollection GetBestellingCollection()
        {
            return new BestellingCollection
            {
                new Bestelling
                {
                    ID = 1,
                    Besteldatum = new System.DateTime(2015, 1, 8),
                    Bestelnummer = 1,
                    BestellingsregelCollection = GetBestellingsRegelCollection(),
                }
            };
        }

        public static GetBestellingByIDRequestMessage GetBestellingByIDRequestMessage()
        {
            return new GetBestellingByIDRequestMessage
            {
                BestellingsID = 1
            };
        }

        public static GetBestellingByIDResponseMessage GetBestellingByIDResponseMessage()
        {
            return new GetBestellingByIDResponseMessage
            {
                Bestelling = new Bestelling
                {
                    ID = 1,
                    Besteldatum = new System.DateTime(2015, 1, 8),
                    Bestelnummer = 1,
                    BestellingsregelCollection = GetBestellingsRegelCollection(),
                    Klant = new Klant
                    {
                        Voornaam = "Testdummy",
                        Achternaam = "McNep",
                        Adresregel1 = "Straatlaan 33",
                        Postcode = "1234AB",
                        Woonplaats = "Plaatsnaam",
                        Telefoonnummer = "1234567890",
                        Klantnummer = "1234567890",
                        Gebruikersnaam = "Wololol",
                    }
                }
            };
        }

        public static BestellingsregelCollection GetBestellingsRegelCollection()
        {
            return new BestellingsregelCollection
            {
                new Bestellingsregel
                {
                    Product = new Product
                    {
                        Naam = "HL Road Frame - Black, 58",
                        LeveranciersProductId = "FR-R92R-58"
                    },
                    Aantal = 3,
                }
            };
        }


        internal static GetAllBestellingenResponseMessage GetAllBestellingenResponseMessage()
        {
            return new GetAllBestellingenResponseMessage
            {
                BestellingCollection = GetBestellingCollection(),
            };
        }
    }
}