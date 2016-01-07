using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Transactions;
using System.Linq;

namespace Leet.Kantilever.PcSWinkelen.DAL.Tests
{
    [TestClass]
    public class WinkelenDALTest
    {
        [ClassInitialize]
        public static void InitailzeClass(TestContext testContext)
        {
            Database.SetInitializer(new WinkelenDBInitializer());

            using (var context = new WinkelenContext())
            {
                context.Database.Initialize(false);
            }
        }

        [TestMethod]
        public void InsertProductTest()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                ProductDataMapper mapper = new ProductDataMapper();
                var dummyProduct = DummyData.GetProduct();

                // Act
                mapper.Insert(dummyProduct);

                // Assert
                var products = mapper.FindAll();
                Assert.AreEqual(3, products.Count());
            }
        }

        [TestMethod]
        public void FindByClientIdTest()
        {
            // Arrange
            ProductDataMapper mapper = new ProductDataMapper();

            // Act
            var products = mapper.FindByClientId("ID01").ToArray();

            // Assert
            Assert.AreEqual(2, products.Count());
            var expextedProducts = DummyData.GetProducts().ToArray();
            AssertProducts(products, expextedProducts);
        }



        private static void AssertProducts(Entities.Product[] products, Entities.Product[] expextedProducts)
        {
            for (int i = 0; i < products.Length; i++)
            {
                Assert.AreEqual(expextedProducts[i].AfbeeldingURL, products[i].AfbeeldingURL);
                Assert.AreEqual(expextedProducts[i].Beschrijving, products[i].Beschrijving);
                Assert.AreEqual(expextedProducts[i].LeverancierNaam, products[i].LeverancierNaam);
                Assert.AreEqual(expextedProducts[i].LeveranciersProductId, products[i].LeveranciersProductId);
                Assert.AreEqual(expextedProducts[i].LeverbaarTot, products[i].LeverbaarTot);
                Assert.AreEqual(expextedProducts[i].LeverbaarVanaf, products[i].LeverbaarVanaf);
                Assert.AreEqual(expextedProducts[i].Naam, products[i].Naam);
                Assert.AreEqual(expextedProducts[i].Prijs, products[i].Prijs);
                Assert.AreEqual(expextedProducts[i].ClientID, products[i].ClientID);
            }
        }
    }
}
