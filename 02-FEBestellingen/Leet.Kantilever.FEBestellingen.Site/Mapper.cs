using System;
using minorcase3pcsbestellen.v1.schema;
using System.Collections.Generic;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Linq;

namespace Leet.Kantilever.FEBestellingen.Site
{
    public class Mapper
    {
        public static IEnumerable<BestellingVM> MapBestellingToVMList(BestellingCollection bestellingen)
        {
            return bestellingen.Select(bestelling => new BestellingVM
            {
                Bestelnummer = bestelling.Bestelnummer,
                Bestellingsregels = MapBestellingsregelToVMList(bestelling.BestellingsregelCollection),
                Besteldatum = bestelling.Besteldatum,
            });
        }

        public static BestellingVM MapBestellingToVMList(Bestelling bestelling)
        {
            return new BestellingVM
            {
                Bestelnummer = bestelling.Bestelnummer,
                Bestellingsregels = MapBestellingsregelToVMList(bestelling.BestellingsregelCollection),
                Besteldatum = bestelling.Besteldatum,
            };
        }

        private static List<BestellingsRegelVM> MapBestellingsregelToVMList(BestellingsregelCollection bestellingsregels)
        {
            return bestellingsregels.Select(regel => new BestellingsRegelVM
            {
                ProductNaam = regel.Product.Naam,
                Leverancierscode = regel.Product.LeveranciersProductId,
                Aantal = regel.Aantal,
            }).ToList();

        }

        public static FactuurVM BestellingToFactuurVM(Bestelling bestelling)
        {
            return new FactuurVM
            {
                Bestelling = new BestellingVM
                {
                    Besteldatum = bestelling.Besteldatum,
                    Bestellingsregels = MapBestellingsregelToVMList(bestelling.BestellingsregelCollection),
                    Bestelnummer = bestelling.Bestelnummer
                },
                Klant = bestelling.Klant
            };
        }

    }
}