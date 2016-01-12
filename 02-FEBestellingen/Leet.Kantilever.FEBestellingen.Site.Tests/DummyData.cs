using System;
using minorcase3pcsbestellen.v1.schema;
using schemaswwwkantilevernl.bscatalogusbeheer.product.v1;

namespace Leet.Kantilever.FEBestellingen.Site.Tests
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
    }
}