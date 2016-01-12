using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.DAL.entities;
using System.Transactions;

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
            List<Bestelling> bestellingen = new List<Bestelling>();

            // Act
            using (var context = new BestellingContext())
            {
                bestellingen = context.Bestellingen.ToList();

            }

            // Assert
            Assert.AreEqual(1, bestellingen.Count);
        }


        [TestMethod]
        public void GetBestellingByIDTest()
        {
            // Arrange
            using (var scope = new TransactionScope())
            {

            }
            // Act

            // Assert

        }
    }
}
