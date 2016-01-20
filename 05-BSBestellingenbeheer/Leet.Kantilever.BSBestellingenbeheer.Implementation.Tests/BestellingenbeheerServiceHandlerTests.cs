using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.BSBestellingenbeheer.DAL.mappers;
using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using Moq;
using Leet.Kantilever.BSBestellingenbeheer.V1.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Leet.Kantilever.BSBestellingenbeheer.Implementation.Tests
{
    [TestClass]
    public class BestellingenbeheerServiceHandlerTests
    {
        [TestMethod]
        public void GetAllBestellingenByKlant_GeeftLijstTerug()
        {
            //arrange
            var mockMapper = new Mock<IDatamapper<Bestelling>>();
            var handler = new BestellingenbeheerServiceHandler(mockMapper.Object);
            var list = DummyData.GetDummyBestellingen().Where(b => b.Klantnummer == "Client02");
            mockMapper.Setup(m => m.Find(It.IsAny<Func<Bestelling, bool>>())).Returns(list);


            var request = new GetAllBestellingenByKlantRequestMessage
            {
                KlantNummer = "Client02"
            };

            //act 
            var result = handler.GetAllBestellingenByKlant(request).BestellingCollection as List<V1.Schema.Bestelling>;

            //assert
            Assert.AreEqual(5, result.First().ID);
        }

        [TestMethod]
        public void GetAllBestellingenByKlant_GeeftLegeLijstTerugBijOnbekendeKlant()
        {
            //arrange
            var mockMapper = new Mock<IDatamapper<Bestelling>>();
            var handler = new BestellingenbeheerServiceHandler(mockMapper.Object);
            var list = DummyData.GetDummyBestellingen().Where(b => b.Klantnummer == "Client012");
            mockMapper.Setup(m => m.Find(It.IsAny<Func<Bestelling, bool>>())).Returns(list);


            var request = new GetAllBestellingenByKlantRequestMessage
            {
                KlantNummer = "Client012"
            };

            //act 
            var result = handler.GetAllBestellingenByKlant(request).BestellingCollection as List<V1.Schema.Bestelling>;

            //assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
