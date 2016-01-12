using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.DAL.entities;

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

            // Act

            // Assert

            List<Bestelling> bestellingen = new List<Bestelling>();
            using (var context = new BestellingContext())
            {
                bestellingen = context.Bestellingen.ToList();

            }
            Assert.AreEqual(1, bestellingen.Count);

        }
    }
}
