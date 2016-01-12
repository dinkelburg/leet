using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

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
        public void thisShouldDescribeTheTest()
        {
            // Arrange

            // Act

            // Assert
            using (var context = new BestellingContext())
            {
                context.Bestellingen.Add(DummyDataDAL.GetBestelling());

            }

        }
    }
}
