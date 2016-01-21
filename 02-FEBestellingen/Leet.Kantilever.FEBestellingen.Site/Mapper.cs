using System;
using minorcase3pcsbestellen.v1.schema;
using System.Collections.Generic;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Linq;

namespace Leet.Kantilever.FEBestellingen.Site
{
    public static class Mapper
    {
        public static IEnumerable<BestellingVM> MapBestellingToVMList(BestellingCollection bestellingen)
        {
            return bestellingen.Select(bestelling => new BestellingVM(MapBestellingsregelToVMList(bestelling.BestellingsregelCollection))
            {
                Bestelnummer = bestelling.Bestelnummer,
                Besteldatum = bestelling.Besteldatum,
            });
        }

        public static BestellingVM MapBestellingToVMList(Bestelling bestelling)
        {
            if(bestelling == null)
            {
                throw new ArgumentNullException("bestelling", "No argument passed.");
            }

            return new BestellingVM(MapBestellingsregelToVMList(bestelling.BestellingsregelCollection))
            {
                Bestelnummer = bestelling.Bestelnummer,
                Besteldatum = bestelling.Besteldatum,
            };
        }

        private static List<BestellingsregelVM> MapBestellingsregelToVMList(BestellingsregelCollection bestellingsregels)
        {
            return bestellingsregels.Select(regel => new BestellingsregelVM
            {
                ProductNaam = regel.Product.Naam,
                Leverancierscode = regel.Product.LeveranciersProductId,
                Aantal = regel.Aantal,
                LeveranciersNaam = regel.Product.LeverancierNaam,
                Prijs = regel.Product.Prijs
            }).ToList();

        }

        public static FactuurVM BestellingToFactuurVM(Bestelling bestelling)
        {
            if (bestelling == null)
            {
                throw new ArgumentNullException("bestelling", "Geef een bestelling mee.");
            }

            return new FactuurVM
            {
                Bestelling = new BestellingVM(MapBestellingsregelToVMList(bestelling.BestellingsregelCollection))
                {
                    Besteldatum = bestelling.Besteldatum,
                    Bestelnummer = bestelling.Bestelnummer,
                    Status = (BestellingVM.BestellingStatusVM)((int) bestelling.Status),               
                },
                Klant = bestelling.Klant
            };
        }

        public static IEnumerable<BestellingListVM> BestellingListToBestellingListVM(IEnumerable<Bestelling> bestellingen)
        {
            return bestellingen.Select(b => new BestellingListVM
            {
                Bestelnummer = b.Bestelnummer,
                TotaalPrijs = b.BestellingsregelCollection.Sum(br => br.Product.Prijs * br.Aantal).Value,
                AantalProducten = b.BestellingsregelCollection.Sum(br => br.Aantal),
            });
        }

    }
}