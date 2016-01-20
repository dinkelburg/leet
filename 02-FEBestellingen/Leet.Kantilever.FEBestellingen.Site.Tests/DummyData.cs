using System;
using minorcase3pcsbestellen.v1.schema;
using schemaswwwkantilevernl.bscatalogusbeheer.product.v1;
using minorcase3bsklantbeheer.v1.schema;

namespace Leet.Kantilever.FEBestellingen.Site.Tests
{
    public static class DummyData
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


        public static Bestelling GetBestelling()
        {
            return new Bestelling
            {
                ID = 1,
                Besteldatum = new System.DateTime(2015, 1, 8),
                Bestelnummer = 1,
                Status = minorcase3bsbestellingenbeheer.v1.schema.BestellingStatus.Nieuw,
                BestellingsregelCollection = new BestellingsregelCollection
            {
                new Bestellingsregel
                {
                    Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                    {
                        Naam = "HL Road Frame - Black, 58",
                        LeverancierNaam = "Batavus",
                        Prijs = 1234m
                    },
                    Aantal = 3,
                },
                new Bestellingsregel
                {
                    Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                    {
                        Naam = "X1 RaceFiets",
                        LeverancierNaam = "Sparta",
                        Prijs = 324m
                    },
                    Aantal = 2,
                }
            },
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
                        LeveranciersProductId = "FR-R92R-58",
                        LeverancierNaam = "Batavus"
                    },
                    Aantal = 3,
                }
            };
        }
    }
}