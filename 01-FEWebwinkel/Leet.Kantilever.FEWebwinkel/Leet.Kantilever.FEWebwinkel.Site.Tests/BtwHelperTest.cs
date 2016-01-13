using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests
{
    [TestClass]
    public class BtwHelperTest
    {
        [TestMethod]
        public void BerekenBtwOverProduct21Procent()
        {
            //arrange
            var originalPrice = 10.00m;

            //act
            var newPrice = BtwHelper.CalculateBtw(originalPrice);

            //assert
            Assert.AreEqual(12.10m, newPrice);
        }

        [TestMethod]
        public void TestBtwConfigSection()
        {
            var btwTarief = ConfigurationManager.GetSection("btw/tarieven") as BtwConfigSection;
            var section = ConfigurationManager.GetSection("btw/tarieven");

            var tarieven = (section as BtwConfigSection).Tarieven;
            
            Assert.AreEqual(2, tarieven.Count);
        }
    }
}
