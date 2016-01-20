using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using PcSBestellen = minorcase3pcsbestellen.v1.schema;
namespace Leet.Kantilever.FEBestellingen.Agent.Tests
{
    [TestClass]
    public class BestellingTest
    {
        [TestMethod]
        public void GoedgekeurdSetStatusBetaald_GoedgekeurdAndBetaaldTest()
        {
            //Arrange
            PcSBestellen.Bestelling bestelling = new PcSBestellen.Bestelling
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
            PcSBestellen.Bestelling bestelling = new PcSBestellen.Bestelling
            {
                Status = (int)(Bestellingsstatus.Goedgekeurd | Bestellingsstatus.Betaald)
            };

            //Act
            bestelling.SetStatus(Bestellingsstatus.Betaald);

            //Assert
            Assert.AreEqual((int)(Bestellingsstatus.Goedgekeurd | Bestellingsstatus.Betaald), bestelling.Status);
        }

        [TestMethod]
        public void NieuwSetStatusGoedgekeurd_StatusGoedgekeurdTest()
        {
            //Arrange
            PcSBestellen.Bestelling bestelling = new PcSBestellen.Bestelling
            {
                Status = (int)Bestellingsstatus.Nieuw,
            };

            //Act
            bestelling.SetStatus(Bestellingsstatus.Goedgekeurd);

            //Assert
            Assert.AreEqual((int)Bestellingsstatus.Goedgekeurd, bestelling.Status);
        }
    }
}
