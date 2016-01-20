using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Leet.Kantilever.PcSBestellen.Host.Tests
{
    [TestClass]
    public class ConfigTests
    {

        [TestMethod]
        public void OrderLimiet_LeesHuidigeWaardeUitTest()
        {
            // Arrange

            // Act
            int limiet;
            int.TryParse(ConfigurationManager.AppSettings["limiet"], out limiet);

            // Assert
            Assert.AreEqual(10, limiet);
        }
    }
}
