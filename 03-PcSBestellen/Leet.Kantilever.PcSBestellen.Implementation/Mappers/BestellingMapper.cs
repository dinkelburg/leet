using Kantilever.BsCatalogusbeheer.Product.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSBestellen.Implementation.Mappers
{
    public class BestellingMapper
    {
        public PcSBestellen.V1.Schema.Bestelling ConvertToPcsBestelling(BSBestellingenbeheer.V1.Schema.Bestelling bestelling)
        {
            V1.Schema.BestellingsregelCollection regels = new PcSBestellen.V1.Schema.BestellingsregelCollection();
            // Copy regels
            bestelling.Bestellingsregels.ForEach(r => regels.Add(ConvertToPcSBestellingregel(r)));
            // Create and return PcSBestellen Bestelling
            return new PcSBestellen.V1.Schema.Bestelling
            {
                Besteldatum = bestelling.Besteldatum,
                BestellingsregelCollection = regels,
            };
        }

        public PcSBestellen.V1.Schema.Bestellingsregel ConvertToPcSBestellingregel(BSBestellingenbeheer.V1.Schema.Bestellingsregel regel)
        {
            return new V1.Schema.Bestellingsregel
            {
                Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                {
                    Id = (int)regel.ProductID,
                    Prijs = regel.Prijs
                },
                Aantal = regel.Aantal
            };
        }

        public void AddProductsToBestelling(PcSBestellen.V1.Schema.Bestelling bestelling, IEnumerable<Product> producten)
        {
            bestelling.BestellingsregelCollection.ForEach(r =>
            {
                try
                {
                    var product = producten.Single(p => p.Id == r.Product.Id);

                    var cats = new schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.CategorieCollection();
                    cats.AddRange(
                        product.CategorieLijst.Select(c => 
                        new schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.Categorie
                        {
                            Id = c.Id,
                            Naam = c.Naam
                        }
                    ));

                    r.Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                    {
                        Id = product.Id,
                        AfbeeldingURL = product.AfbeeldingURL,
                        Beschrijving = product.Beschrijving,
                        CategorieLijst = cats,
                        LeverancierNaam = product.LeverancierNaam,
                        LeveranciersProductId = product.LeveranciersProductId,
                        LeverbaarTot = product.LeverbaarTot,
                        LeverbaarVanaf = product.LeverbaarVanaf,
                        Naam = product.Naam,
                        Prijs = product.Prijs,
                    };
                } catch { }
            });
        }


    }
}
