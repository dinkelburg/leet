using Kantilever.BsCatalogusbeheer.Product.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using minorcase3bsklantbeheer.v1.schema;

namespace Leet.Kantilever.PcSBestellen.Implementation.Mappers
{
    public static class BestellingMapper
    {
        /// <summary>
        /// Convert From BSBestellingenbeheer bestelling to PcSBestellen bestelling 
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        public static PcSBestellen.V1.Schema.Bestelling ConvertToPcsBestelling(BSBestellingenbeheer.V1.Schema.Bestelling bestelling)
        {
            V1.Schema.BestellingsregelCollection regels = new PcSBestellen.V1.Schema.BestellingsregelCollection();
            // Copy regels if Bestellingsregels isn't null
            bestelling.Bestellingsregels?.ForEach(r => regels.Add(ConvertToPcSBestellingsregel(r)));
            // Create and return PcSBestellen Bestelling
            return new PcSBestellen.V1.Schema.Bestelling
            {
                Besteldatum = bestelling.Besteldatum,
                BestellingsregelCollection = regels,
                Bestelnummer = bestelling.Bestelnummer,
                ID = bestelling.ID,
                Ingepakt = bestelling.Ingepakt,
            };
        }

        public static BSBestellingenbeheer.V1.Schema.Bestelling ConvertToBSBestelling(PcSBestellen.V1.Schema.Bestelling bestelling)
        {
            //Map regels
            var regels = new BSBestellingenbeheer.V1.Schema.BestellingsregelCollection();
            regels.AddRange(bestelling.BestellingsregelCollection.Select(r => ConvertToBSBestellingsregel(r)));

            //Map bestelling
            return new BSBestellingenbeheer.V1.Schema.Bestelling
            {
                Besteldatum = bestelling.Besteldatum,
                Bestelnummer = bestelling.Bestelnummer,
                Klantnummer = bestelling.Klant.Klantnummer,
                Bestellingsregels = regels,
                ID = 0,
                Ingepakt = bestelling.Ingepakt,
            };
        }


        /// <summary>
        /// Convert PcSBestelling bestellingsregel to BSBestelling bestellingsregel
        /// </summary>
        /// <param name="regel"></param>
        /// <returns></returns>
        public static BSBestellingenbeheer.V1.Schema.Bestellingsregel ConvertToBSBestellingsregel(PcSBestellen.V1.Schema.Bestellingsregel regel)
        {
            return new BSBestellingenbeheer.V1.Schema.Bestellingsregel
            {
                Aantal = regel.Aantal,
                Prijs = regel.Product.Prijs ?? 0,
                ProductID = regel.Product.Id ?? 0
            };
        }

        /// <summary>
        /// Convert a BSBestellingbeheer bestellingsregel to a PcSBestellen bestellingsregel
        /// </summary>
        /// <param name="regel"></param>
        /// <returns></returns>
        public static PcSBestellen.V1.Schema.Bestellingsregel ConvertToPcSBestellingsregel(BSBestellingenbeheer.V1.Schema.Bestellingsregel regel)
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

        /// <summary>
        /// Add product information to a PcSBestellen bestelling
        /// </summary>
        /// <param name="bestelling"></param>
        /// <param name="producten"></param>
        public static void AddProductsToBestelling(PcSBestellen.V1.Schema.Bestelling bestelling, IEnumerable<Product> producten)
        {
            //Loop through all Bestellingsregels and update product information
            bestelling.BestellingsregelCollection.ForEach(r =>
            {
                try
                {
                    // See if the product can be found 
                    var product = producten.Single(p => p.Id == r.Product.Id);

                    // Add Categories
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
                        Prijs = r.Product.Prijs,
                    };
                }
                catch (InvalidOperationException) { /*Product not found, skip*/ }
            });
        }

        internal static minorcase3bsklantbeheer.v1.schema.Klant ConvertToBSKlant(BSKlantbeheer.V1.Schema.Klant klant)
        {
            return new minorcase3bsklantbeheer.v1.schema.Klant
            {
                ID = klant.ID,
                Voornaam = klant.Voornaam,
                Tussenvoegsel = klant.Tussenvoegsel,
                Achternaam = klant.Achternaam,
                Adresregel1 = klant.Adresregel1,
                Adresregel2 = klant.Adresregel2,
                Email = klant.Email,
                Gebruikersnaam = klant.Gebruikersnaam,
                Klantnummer = klant.Klantnummer,
                Postcode = klant.Postcode,
                Telefoonnummer = klant.Telefoonnummer,
                Woonplaats = klant.Woonplaats,
            };
        }

        /// <summary>
        /// Convert a PcSWinkelen winkelmand to a PcSBestellen bestelling
        /// </summary>
        /// <param name="winkelmand"></param>
        /// <returns></returns>
        public static PcSBestellen.V1.Schema.Bestelling ConvertWinkelmandToBestelling(PcSWinkelen.V1.Schema.Winkelmand winkelmand)
        {
            var bestelling = new PcSBestellen.V1.Schema.Bestelling
            {
                BestellingsregelCollection = new V1.Schema.BestellingsregelCollection(),
                Ingepakt = false,
            };

            foreach (var regel in winkelmand)
            {
                // Map Categorieen
                schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.CategorieCollection catCollection = null;
                if (regel.Product.CategorieLijst != null)
                {
                    var categorieen = regel.Product.CategorieLijst.Select(c => new schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.Categorie { Id = c.Id, Naam = c.Naam });
                    catCollection = new schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.CategorieCollection();
                    catCollection.AddRange(categorieen);
                }


                //Map regels
                bestelling.BestellingsregelCollection.Add(new V1.Schema.Bestellingsregel
                {
                    Aantal = regel.Aantal,
                    Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                    {
                        AfbeeldingURL = regel.Product.AfbeeldingURL,
                        Beschrijving = regel.Product.Beschrijving,
                        CategorieLijst = catCollection ?? new schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.CategorieCollection(),
                        Id = regel.Product.Id,
                        LeverancierNaam = regel.Product.LeverancierNaam,
                        LeveranciersProductId = regel.Product.LeveranciersProductId,
                        LeverbaarTot = regel.Product.LeverbaarTot,
                        LeverbaarVanaf = regel.Product.LeverbaarVanaf,
                        Naam = regel.Product.Naam,
                        Prijs = regel.Product.Prijs,
                    }
                });
            }

            return bestelling;
        }

    }
}
