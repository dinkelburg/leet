using Leet.Kantilever.PcSBestellen.Implementation.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KantileverAlias = Kantilever.BsCatalogusbeheer;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Implementation.Tests
{
    public static class DummyData
    {
        /// <summary>
        /// Returns the following list of products {
        ///     (
        ///      Id: 1, 
        ///      Beschrijving: Blauwe fiets, 
        ///      LeverancierNaam: De boer fietsen,
        ///      LeveranciersProductId: DBF15432,
        ///      Naam: Batavus sport blauw,
        ///      Prijs: 945.00,
        ///      CategorieLijst: {
        ///         (Id: 1, Naam: Fietsen)
        ///      }
        ///     )
        /// }
        /// </summary>
        public static List<KantileverAlias.Product.V1.Product> BSCatalogusProductList {
            get {
                var cats = new KantileverAlias.Categorie.V1.CategorieCollection();
                cats.Add(new KantileverAlias.Categorie.V1.Categorie {
                    Id = 1,
                    Naam = "Fietsen"
                });
                return new List<KantileverAlias.Product.V1.Product> {
                    #region Data
                    new KantileverAlias.Product.V1.Product
                    {
                        AfbeeldingURL = "product.jpg",
                        Beschrijving = "Blauwe fiets",
                        Id = 1,
                        CategorieLijst = cats,
                        LeverancierNaam = "De boer fietsen",
                        LeveranciersProductId = "DBF15432",
                        LeverbaarVanaf = new DateTime(2010, 4, 6),
                        Naam = "Batavus sport blauw",
                        Prijs = 945,
                    }
                    #endregion
                };
            }
        }

        /// <summary>
        /// Returns a bestelling with the following properties: 
        /// Besteldatum: 15-01-2015
        /// Bestelnummer: 24343
        /// ID: 15434
        /// Ingepakt: false
        /// KlantID: 46574676
        /// Bestellingsregels {
        ///     (Aantal: 3, Prijs: 945, ProductID: 1),
        /// }
        /// </summary>
        public static BSBestellingenbeheer.V1.Schema.Bestelling BSBestellingbeheerBestelling {
            get {
                var regels = new BSBestellingenbeheer.V1.Schema.BestellingsregelCollection();
                regels.Add(new BSBestellingenbeheer.V1.Schema.Bestellingsregel
                {
                    Aantal = 3,
                    Prijs = BSCatalogusProductList.First().Prijs ?? 0,
                    ProductID = 1
                });
                return new BSBestellingenbeheer.V1.Schema.Bestelling
                {
                    #region Data
                    Besteldatum = new DateTime(2015, 01, 15),
                    Bestellingsregels = regels,
                    Bestelnummer = 24343,
                    ID = 15434,
                    Status = 8,
                    Klantnummer = "42dffe6f-2b0b-43d5-9e84-8433168def99"
                    #endregion
                };
            }
        }

        /// <summary>
        /// Get BSBestellingbeheerBestelling as a PcSBestellen bestelling
        /// </summary>
        public static V1.Schema.Bestelling PcSBestellenBestelling
        {
            get
            {
                var bestelling = BestellingMapper.ConvertToPcsBestelling(BSBestellingbeheerBestelling);
                bestelling.Klant = new minorcase3bsklantbeheer.v1.schema.Klant
                {
                    Achternaam = "Vries",
                    Adresregel1 = "Softwarelaan 1",
                    Email = "jan@devries.nl",
                    Gebruikersnaam = "jdv",
                    ID = 21,
                    Klantnummer = "42dffe6f-2b0b-43d5-9e84-8433168def99",
                    Postcode = "2449AA",
                    Telefoonnummer = "0234568459",
                    Tussenvoegsel = "de",
                    Voornaam = "Jan",
                    Woonplaats = "Hattem"
                };
                return bestelling;
            }
        }

        /// <summary>
        /// Returns a bestelling with the following properties: 
        /// Besteldatum: 20-01-2016
        /// Bestelnummer: 523425
        /// ID: 523425
        /// Status: Nieuw (1)
        /// KlantID: 12464
        /// Bestellingsregels {
        ///     (Aantal: 2, Prijs: 6.50, ProductID: 123),
        /// }
        public static V1.Schema.Bestelling PcSBestellenBestellingGoedkoop
        {
            get
            {
                return new V1.Schema.Bestelling
                {
                    Besteldatum = new DateTime(2016, 1, 20),
                    Bestelnummer = 523425,
                    ID = 523425,
                    Klant = Klant,
                    Status = 1,
                    BestellingsregelCollection = new V1.Schema.BestellingsregelCollection
                    {
                        new V1.Schema.Bestellingsregel
                        {
                            Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                            {
                                Id = 123,
                                Beschrijving = "Voorbeeldproduct",
                                Naam = "Fietsketting",
                                Prijs = 6.50m
                            },
                            Aantal = 2
                        }
                    }
                };
            }
        }



        /// <summary>
        /// Fill a winkelmand with the following data
        /// {
        ///     Aantal = 1,
        ///     Product = 
        ///     (
        ///      Id: 1, 
        ///      Beschrijving: Blauwe fiets, 
        ///      LeverancierNaam: De boer fietsen,
        ///      LeveranciersProductId: DBF15432,
        ///      Naam: Batavus sport blauw,
        ///      Prijs: 945.00,
        ///      CategorieLijst: {
        ///         (Id: 1, Naam: Fietsen)
        ///      }
        ///     )
        /// }
        /// </summary>
        public static PcSWinkelen.V1.Schema.Winkelmand PcSWinkelenWinkelmand {
            get {
                var mand = new PcSWinkelen.V1.Schema.Winkelmand();
                var cats = new BSCatalogusbeheer.V1.Categorie.CategorieCollection();
                cats.Add(new BSCatalogusbeheer.V1.Categorie.Categorie
                {
                    Id = BSCatalogusProductList.First().CategorieLijst.First().Id,
                    Naam = BSCatalogusProductList.First().CategorieLijst.First().Naam,
                });
                mand.Add(new PcSWinkelen.V1.Schema.WinkelmandRegel
                {
                    Aantal = 1,
                    Product = new BSCatalogusbeheer.V1.Product.Product {
                        AfbeeldingURL = BSCatalogusProductList.First().AfbeeldingURL,
                        Beschrijving = BSCatalogusProductList.First().Beschrijving,
                        Id = BSCatalogusProductList.First().Id,
                        LeverancierNaam = BSCatalogusProductList.First().LeverancierNaam,
                        LeveranciersProductId = BSCatalogusProductList.First().LeveranciersProductId,
                        LeverbaarTot = BSCatalogusProductList.First().LeverbaarTot,
                        LeverbaarVanaf = BSCatalogusProductList.First().LeverbaarVanaf,
                        Naam = BSCatalogusProductList.First().Naam,
                        Prijs = BSCatalogusProductList.First().Prijs,
                        CategorieLijst = cats,
                    }
                });
                return mand;
            }
        }

        public static minorcase3bsklantbeheer.v1.schema.Klant Klant {
            get
            {
                return new minorcase3bsklantbeheer.v1.schema.Klant
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
                };
            }
        }

        public static Klant BsKlant
        {
            get
            {
                return new Klant
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
                };
            }
        }
    }
}
