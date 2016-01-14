using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.PcSBestellen.Implementation.Mappers;
using ProductAlias = Kantilever.BsCatalogusbeheer;
using System.Collections.Generic;
using System.Linq;

namespace Leet.Kantilever.PcSBestellen.Implementation.Tests
{
    [TestClass]
    public class BestellingMapperTests
    {
        [TestMethod]
        public void BSBestellingToPcSBestellingReturnsCorrectType()
        {
            // Arrange
            var mapper = new BestellingMapper();
            var BSBestelling = new BSBestellingenbeheer.V1.Schema.Bestelling();

            // Act
            var PcSBestelling = mapper.ConvertToPcsBestelling(BSBestelling);

            // Assert
            Assert.IsInstanceOfType(PcSBestelling, typeof(PcSBestellen.V1.Schema.Bestelling));
            Assert.IsNotNull(PcSBestelling);
        }

        [TestMethod]
        public void BSBestellingToPcSBestellingReturnsCorrectValues()
        {
            // Arrange
            var mapper = new BestellingMapper();
            var BSBestelling = new BSBestellingenbeheer.V1.Schema.Bestelling
            {
                Besteldatum = new DateTime(2015,10,01),
                Bestelnummer = 2045,
                ID = 32115,
                Klantnummer = "Client01",
                Bestellingsregels = new BSBestellingenbeheer.V1.Schema.BestellingsregelCollection(),
            };
            
            BSBestelling.Bestellingsregels.AddRange(new List<BSBestellingenbeheer.V1.Schema.Bestellingsregel> {
                new BSBestellingenbeheer.V1.Schema.Bestellingsregel {Aantal = 1, Prijs = 10, ProductID = 2 },
                new BSBestellingenbeheer.V1.Schema.Bestellingsregel {Aantal = 2, Prijs = 15, ProductID = 1 },
                new BSBestellingenbeheer.V1.Schema.Bestellingsregel {Aantal = 3, Prijs = 20, ProductID = 4 },
            });

            // Act
            var PcSBestelling = mapper.ConvertToPcsBestelling(BSBestelling);

            // Assert
            Assert.IsNotNull(PcSBestelling.BestellingsregelCollection);
            Assert.AreEqual(PcSBestelling.BestellingsregelCollection.Count, 3);
            Assert.AreEqual(PcSBestelling.BestellingsregelCollection.First().Product.Id, 2);
            Assert.AreEqual(PcSBestelling.BestellingsregelCollection.First().Aantal, 1);
            Assert.AreEqual(PcSBestelling.BestellingsregelCollection.First().Product.Prijs, 10M);
        }

        [TestMethod]
        public void BSBestellingsregelToPcSBestellingsRegelReturnsCorrectValues()
        {
            // Arrange
            var BSregel = new BSBestellingenbeheer.V1.Schema.Bestellingsregel
            {
               ProductID = 1,
               Aantal = 3,
               Prijs = 15.5M,
            };
            var mapper = new BestellingMapper();

            // Act
            var PcSRegel = mapper.ConvertToPcSBestellingregel(BSregel);

            // Assert
            Assert.IsNotNull(PcSRegel);
            Assert.IsInstanceOfType(PcSRegel, typeof(PcSBestellen.V1.Schema.Bestellingsregel));
            Assert.AreEqual(PcSRegel.Product.Id, 1);
            Assert.AreEqual(PcSRegel.Aantal, 3);
            Assert.AreEqual(PcSRegel.Product.Prijs, 15.5M);
        }

        [TestMethod]
        public void AddProductsToBestellingAddsProductInformation()
        {
            // Arrange
            var mapper = new BestellingMapper();
            var PcSBestelling = new PcSBestellen.V1.Schema.Bestelling
            {
                #region Data
                Besteldatum = new DateTime(2004,4,24),
                ID = 2374,
                Bestelnummer = 23451,
                Klant = new minorcase3bsklantbeheer.v1.schema.Klant
                {
                    ID = 2124,
                    Achternaam = "de Vries",
                    Adresregel1 = "Softwarelaan 43",
                    Email = "jan@devries.nl",
                    Klantnummer = "2134",
                    Postcode = "5434CC",
                    Telefoonnummer = "0645774121",
                    Voornaam = "Jan"
                },
                BestellingsregelCollection = new V1.Schema.BestellingsregelCollection(),
                #endregion
            };
            
            var products = new List<ProductAlias.Product.V1.Product>
            {
                #region Data
                new ProductAlias.Product.V1.Product
                {
                    AfbeeldingURL = "/images/product.jpg",
                    Beschrijving = "Blauwe fiets",
                    Id = 154,
                    LeverancierNaam = "De Boer Fietsen",
                    LeveranciersProductId = "DBF10254632",
                    LeverbaarTot = null,
                    LeverbaarVanaf = new DateTime(2003, 2, 14),
                    Naam = "Fiets F1024",
                    Prijs = 299.99M,
                    CategorieLijst = new ProductAlias.Categorie.V1.CategorieCollection()
                }
                #endregion
            };
            products.First().CategorieLijst.Add(new ProductAlias.Categorie.V1.Categorie { Id = 1, Naam = "Fietsen" });

            PcSBestelling.BestellingsregelCollection.Add(new V1.Schema.Bestellingsregel
            {
                #region Data
                Aantal = 2,
                Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                {
                    Id = 154,
                }
                #endregion
            });


            //Act
            mapper.AddProductsToBestelling(PcSBestelling, products);

            var PcSproduct = PcSBestelling.BestellingsregelCollection.First().Product;
            var BSProduct = products.First();

            // Assert
            Assert.AreEqual(BSProduct.AfbeeldingURL, PcSproduct.AfbeeldingURL);
            Assert.AreEqual(BSProduct.Beschrijving, PcSproduct.Beschrijving);
            Assert.AreEqual(BSProduct.Id, PcSproduct.Id);
            Assert.AreEqual(BSProduct.LeverancierNaam, PcSproduct.LeverancierNaam);
            Assert.AreEqual(BSProduct.LeveranciersProductId, PcSproduct.LeveranciersProductId);
            Assert.AreEqual(BSProduct.LeverbaarTot, PcSproduct.LeverbaarTot);
            Assert.AreEqual(BSProduct.LeverbaarVanaf, PcSproduct.LeverbaarVanaf);
            Assert.AreEqual(BSProduct.Naam, PcSproduct.Naam);
            Assert.AreEqual(null, PcSproduct.Prijs); //Mapper should not take price from BSCatalogus but from BSBestellen, in this case the value is null null
            Assert.AreEqual(BSProduct.CategorieLijst.First().Id, PcSproduct.CategorieLijst.First().Id);
            Assert.AreEqual(BSProduct.CategorieLijst.First().Naam, PcSproduct.CategorieLijst.First().Naam);

        }

        [TestMethod]
        public void AddProductsToBestellingDoesNotThrowErrorWhenProductNotFound()
        {
            // Arrange
            var mapper = new BestellingMapper();
            var PcSBestelling = new PcSBestellen.V1.Schema.Bestelling
            {
                #region Data
                Besteldatum = new DateTime(2004, 4, 24),
                ID = 2374,
                Bestelnummer = 23451,
                Klant = new minorcase3bsklantbeheer.v1.schema.Klant
                {
                    ID = 2124,
                    Achternaam = "de Vries",
                    Adresregel1 = "Softwarelaan 43",
                    Email = "jan@devries.nl",
                    Klantnummer = "21464",
                    Postcode = "5434CC",
                    Telefoonnummer = "0645774121",
                    Voornaam = "Jan"
                },
                BestellingsregelCollection = new V1.Schema.BestellingsregelCollection(),
                #endregion
            };

            var products = new List<ProductAlias.Product.V1.Product> { };
            
            PcSBestelling.BestellingsregelCollection.Add(new V1.Schema.Bestellingsregel
            {
                #region Data
                Aantal = 2,
                Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                {
                    Id = 154,
                }
                #endregion
            });


            // Act
            mapper.AddProductsToBestelling(PcSBestelling, products);

            // Assert
            //No Error thrown
        }
    }
}
