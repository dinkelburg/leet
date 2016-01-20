using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Leet.Kantilever.FEBestellingen.Agent;
using Leet.Kantilever.FEBestellingen.Site.Controllers;
using minorcase3pcsbestellen.v1.schema;
using System.Web.Mvc;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace Leet.Kantilever.FEBestellingen.Site.Tests.Controllers
{
    [TestClass]
    public class BestellingControllerTests
    {
        [TestMethod]
        public void ToonFactuur_RoeptFindBestellingByBestelnummerVanAgentAanTest()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(DummyData.GetBestelling());
            var controller = new BestellingController(agentMock.Object);

            //act
            var viewResult = controller.ToonFactuur(1) as ViewResult;
            var bestelling = (viewResult.Model as FactuurVM).Bestelling;
            var result = bestelling.Bestellingsregels.First();

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(1), Times.Once);
            Assert.AreEqual("Batavus", result.LeveranciersNaam);
        }

        [TestMethod]
        public void VolgendeBestelling_RoeptFindVolgendeOpenBestellingVanAgentAanTest()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindVolgendeOpenBestelling()).Returns(DummyData.GetBestelling());
            var controller = new BestellingController(agentMock.Object);

            //act
            var viewResult = controller.VolgendeBestelling() as ViewResult;
            var bestellingsregels = (viewResult.Model as BestellingVM).Bestellingsregels;
            var result = bestellingsregels.First();

            //assert
            agentMock.Verify(m => m.FindVolgendeOpenBestelling(), Times.Once);
            Assert.AreEqual("Batavus", result.LeveranciersNaam);
        }

        [TestMethod]
        public void Index_RoeptFindAllBestellingenVanAgentAanTest()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindAllBestellingen()).Returns(DummyData.GetBestellingCollection());
            var controller = new BestellingController(agentMock.Object);

            //act
            var viewResult = controller.Index() as ViewResult;
            var bestellingCollection = (viewResult.Model as IEnumerable<BestellingVM>);
            var result = bestellingCollection.First().Bestellingsregels.First().LeveranciersNaam;

            //assert
            agentMock.Verify(m => m.FindAllBestellingen(), Times.Once);
            Assert.AreEqual("Batavus", result);
        }
    }
}
