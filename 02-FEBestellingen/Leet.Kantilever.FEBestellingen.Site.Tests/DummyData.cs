using System;
using minorcase3pcsbestellen.v1.schema;
using schemaswwwkantilevernl.bscatalogusbeheer.product.v1;
using minorcase3bsklantbeheer.v1.schema;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using PcSBestellen = minorcase3pcsbestellen.v1.schema;


namespace Leet.Kantilever.FEBestellingen.Site.Tests
{
    public static class DummyData
    {
        public static PcSBestellen.BestellingCollection GetBestellingCollection()
        {
            return new PcSBestellen.BestellingCollection
            {
                new PcSBestellen.Bestelling
                {
                    ID = 1,
                    Besteldatum = new System.DateTime(2015, 1, 8),
                    Bestelnummer = 1,
                    BestellingsregelCollection = GetBestellingsRegelCollection(),
                }
            };
        }


        public static PcSBestellen.Bestelling GetBestelling()
        {
            return new PcSBestellen.Bestelling
            {
                ID = 1,
                Besteldatum = new System.DateTime(2015, 1, 8),
                Bestelnummer = 1,
                Status = (int)BestellingStatus.Nieuw,
                BestellingsregelCollection = new PcSBestellen.BestellingsregelCollection
            {
                new PcSBestellen.Bestellingsregel
                {
                    Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                    {
                        Naam = "HL Road Frame - Black, 58",
                        LeverancierNaam = "Batavus",
                        Prijs = 1234m
                    },
                    Aantal = 3,
                },
                new PcSBestellen.Bestellingsregel
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

        public static PcSBestellen.BestellingsregelCollection GetBestellingsRegelCollection()
        {
            return new PcSBestellen.BestellingsregelCollection
            {
                new PcSBestellen.Bestellingsregel
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