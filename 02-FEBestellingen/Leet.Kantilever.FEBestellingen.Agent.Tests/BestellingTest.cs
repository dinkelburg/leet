using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;

namespace Leet.Kantilever.FEBestellingen.Agent.Tests
{
    [TestClass]
    public class BestellingTest
    {
        [TestMethod]
        public void GoedgekeurdSetStatusBetaald_GoedgekeurdAndBetaaldTest()
        {
            //Arrange
            Bestelling bestelling = new Bestelling
            {
                Status = (int)Bestellingsstatus.Goedgekeurd
            };

            //Act
            bestelling.SetStatus(Bestellingsstatus.Betaald);

            //Assert
            Assert.AreEqual((int)(Bestellingsstatus.Goedgekeurd | Bestellingsstatus.Betaald), bestelling.Status);
        }

        [TestMethod]
        public void GoedgekeurdAndBetaaldSetStatusBetaald_GoedgekeurdAndBetaaldTest()
        {
            //Arrange
            Bestelling bestelling = new Bestelling
            {
                Status = (int)(Bestellingsstatus.Goedgekeurd | Bestellingsstatus.Betaald)
            };

            //Act
            bestelling.SetStatus(Bestellingsstatus.Betaald);

            //Assert
            Assert.AreEqual((int)(Bestellingsstatus.Goedgekeurd | Bestellingsstatus.Betaald), bestelling.Status);
        }
    }
}
