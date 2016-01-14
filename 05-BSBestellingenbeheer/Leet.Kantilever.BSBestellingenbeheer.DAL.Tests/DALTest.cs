using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using Leet.Kantilever.BSBestellingenbeheer.DAL.mappers;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    [TestClass]
    public class DALTest
    {
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Database.SetInitializer(new BestellingDBInitializer());

            using (var context = new BestellingContext())
            {
                context.Database.Initialize(false);
            }

        }

        [TestMethod]
        public void TestGetBestellingen()
        {

            // Arrange
            IBestellingMapper<Bestelling> bestellingMapper = new BestellingDataMapper();

            // Act
            var bestellingen = bestellingMapper.FindAll();
            
            // Assert
            Assert.AreEqual(4, bestellingen.Count());
        }


        [TestMethod]
        public void TestFindBestellingByID()
        {
            // Arrange
            IBestellingMapper<Bestelling> mapper = new BestellingDataMapper();

            // Act
            var bestelling = mapper.FindBestellingByID(2);


            // Assert
            var bestellingsregel = bestelling.Bestellingsregels.Where(regel => regel.ID == 2).First();
            Assert.AreEqual(2, bestelling.ID);
            Assert.IsTrue(bestelling.Ingepakt);
            Assert.AreEqual(1, bestelling.KlantID);
            Assert.AreEqual(2, bestellingsregel.ID);
            Assert.AreEqual(3, bestellingsregel.Aantal);
            Assert.AreEqual(5, bestellingsregel.ProductID);
            Assert.AreEqual(5.5M, bestellingsregel.Prijs);
        }


        [TestMethod]
        public void TestFindVolgendeOpenBestelling()
        {
            // Arrange
            IBestellingMapper<Bestelling> bestellingMapper = new BestellingDataMapper();

            // Act
            var openBestelling = bestellingMapper.FindVolgendeOpenBestelling();

            // Assert
            Assert.AreEqual(3, openBestelling.ID);

        }


        [TestMethod]
        public void AddNieuweBestellingReturntGrotereLijstTest()
        {
            // Arrange
            IBestellingMapper<Bestelling> bestellingMapper = new BestellingDataMapper();

            // Act
            var oudeBestellinglijst = bestellingMapper.FindAll();

            bestellingMapper.AddBestelling(DummyDataDAL.GetBestelling());

            var nieuweBestellinglijst = bestellingMapper.FindAll();

            // Assert
            Assert.AreEqual(4, oudeBestellinglijst.Count());
            Assert.AreEqual(5, nieuweBestellinglijst.Count());

        }
    }
}
