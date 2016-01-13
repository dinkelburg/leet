using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Transactions;
using System.Linq;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;

namespace Leet.Kantilever.PcSWinkelen.DAL.Tests
{
    [TestClass]
    public class WinkelmandDataMapperTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Database.SetInitializer(new WinkelenDBInitializer());

            using (var context = new WinkelenContext())
            {
                context.Database.Initialize(false);
            }
        }


        [TestMethod]
        public void AddProductToWinkelmandWithNewWinkelmandTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                WinkelmandDataMapper mapper = new WinkelmandDataMapper();
                var product = DummyDataDAL.GetProduct();

                // Act
                mapper.AddProductToWinkelmand(product, "Client02");

                // Assert
                var winkelmanden = mapper.FindAll();
                var winkelmand = winkelmanden.SingleOrDefault(w => w.ClientID == "Client02");
                var newProducts = winkelmand.Products;
                Assert.AreEqual(1, newProducts.Count);
                AssertProduct(product, newProducts.First());
            }
        }

        [TestMethod]
        public void AddProductToWinkelmandWithExistingWinkelmandTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                WinkelmandDataMapper mapper = new WinkelmandDataMapper();
                var product = DummyDataDAL.GetProduct();

                // Act
                mapper.AddProductToWinkelmand(product, "Client01");

                // Assert
                var winkelmanden = mapper.FindAll();
                var winkelmand = winkelmanden.SingleOrDefault(w => w.ClientID == "Client01");
                var newProducts = winkelmand.Products;
                Assert.AreEqual(3, newProducts.Count);
                AssertProduct(product, newProducts.FirstOrDefault(p => p.CatalogusProductID == 1));
            }
        }

        [TestMethod]
        public void AddExistingProductToWinkelmandTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                WinkelmandDataMapper mapper = new WinkelmandDataMapper();
                var product = DummyDataDAL.GetProduct();

                // Act
                mapper.AddProductToWinkelmand(product, "Client01");
                mapper.AddProductToWinkelmand(product, "Client01");

                // Assert
                var winkelmanden = mapper.FindAll();
                var winkelmand = winkelmanden.SingleOrDefault(w => w.ClientID == "Client01");
                var newProducts = winkelmand.Products;

                product.Aantal = 2;
                Assert.AreEqual(3, newProducts.Count);
                AssertProduct(newProducts.FirstOrDefault(p => p.CatalogusProductID == 1), product);
            }
        }

        [TestMethod]
        public void AddExistingProductWith10AantalToWinkelmandTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                WinkelmandDataMapper mapper = new WinkelmandDataMapper();
                var product = DummyDataDAL.GetProduct();

                // Act
                mapper.AddProductToWinkelmand(product, "Client01");
                product.Aantal = 10;
                mapper.AddProductToWinkelmand(product, "Client01");

                // Assert
                var winkelmanden = mapper.FindAll();
                var winkelmand = winkelmanden.SingleOrDefault(w => w.ClientID == "Client01");
                var newProducts = winkelmand.Products;

                product.Aantal = 11;
                Assert.AreEqual(3, newProducts.Count);
                AssertProduct(newProducts.FirstOrDefault(p => p.CatalogusProductID == 1), product);
            }
        }

        [TestMethod]
        public void FindWinkelmandByClientId()
        {
            // Arrange
            WinkelmandDataMapper mapper = new WinkelmandDataMapper();

            // Act
            var winkelmanden = mapper.FindAll();

            // Assert
            Assert.AreEqual(1, winkelmanden.Count());
            AssertWinkelmand(winkelmanden.First(), DummyDataDAL.GetWinkelmand());
        }


        [TestMethod]
        public void FindWinkelmandByClientIdTest()
        {
            // Arrange
            WinkelmandDataMapper mapper = new WinkelmandDataMapper();

            // Act
            var winkelmand = mapper.FindWinkelmandByClientId("Client01");

            // Assert
            AssertWinkelmand(winkelmand, DummyDataDAL.GetWinkelmand());
        }

        [TestMethod]
        public void FindWinkelmandByClientIdThatNotExistsTest()
        {
            // Arrange
            WinkelmandDataMapper mapper = new WinkelmandDataMapper();

            // Act
            var winkelmand = mapper.FindWinkelmandByClientId("Client15");

            // Assert
            Assert.IsNull(winkelmand);
        }


        [TestMethod]
        public void RemoveWinkelmandByClientIDTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                WinkelmandDataMapper mapper = new WinkelmandDataMapper();

                // Act
                mapper.RemoveWinkelmandByClientID("Client01");

                // Assert
                var products = mapper.FindAll();
                Assert.AreEqual(0, products.Count());
            }
        }

        [TestMethod]
        public void RemoveWinkelmandByClientIDThatDoesNotExistTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                WinkelmandDataMapper mapper = new WinkelmandDataMapper();
                bool exceptionThrown = false;
                string exceptionMessage = string.Empty;

                try
                {
                    // Act
                    mapper.RemoveWinkelmandByClientID("Client11");
                }
                catch(ArgumentException ex)
                {
                    exceptionThrown = true;
                    exceptionMessage = ex.Message;
                }
                // Assert
                Assert.IsTrue(exceptionThrown);
                Assert.AreEqual("Geen winkelmand gevonden met het ClientID: Client11", exceptionMessage);
            }
        }

        private static void AssertWinkelmand(Winkelmand winkelmand, Winkelmand expectedWinkelmand)
        {
            Assert.AreEqual(expectedWinkelmand.ClientID, winkelmand.ClientID);
            AssertProducts(expectedWinkelmand.Products.ToArray(), winkelmand.Products.ToArray());
        }

        private static void AssertProduct(Entities.Product product, Entities.Product expextedProduct)
        {
            Assert.AreEqual(expextedProduct.AfbeeldingURL, product.AfbeeldingURL);
            Assert.AreEqual(expextedProduct.Beschrijving, product.Beschrijving);
            Assert.AreEqual(expextedProduct.LeverancierNaam, product.LeverancierNaam);
            Assert.AreEqual(expextedProduct.LeveranciersProductId, product.LeveranciersProductId);
            Assert.AreEqual(expextedProduct.LeverbaarTot, product.LeverbaarTot);
            Assert.AreEqual(expextedProduct.LeverbaarVanaf, product.LeverbaarVanaf);
            Assert.AreEqual(expextedProduct.Naam, product.Naam);
            Assert.AreEqual(expextedProduct.Prijs, product.Prijs);
            Assert.AreEqual(expextedProduct.Aantal, product.Aantal);
            Assert.AreEqual(expextedProduct.CatalogusProductID, product.CatalogusProductID);
        }

        private static void AssertProducts(Entities.Product[] products, Entities.Product[] expextedProducts)
        {
            for (int i = 0; i < products.Length; i++)
            {
                AssertProduct(expextedProducts[i], products[i]);
            }
        }
    }
}
