using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Site.Controllers;
using System.Web.Mvc;
using Leet.Kantilever.FEWebwinkel.Agent.Tests;
using Minor.Case3.BsKlantbeheer.V1.Schema;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests.Controllers
{
    [TestClass]
    public class BestellenControllerTest
    {

        [TestMethod]
        public void GegevensInvoerenGetTest()
        {
            // Arrange
            var agentPcSWinkelenMock = new Mock<IAgentPcSWinkelen>(MockBehavior.Strict);
            var agentPcSBestellenMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentPcSWinkelenMock.Setup(agent => agent.GetWinkelmand(It.IsAny<string>())).Returns(DummyData.GetWinkelmand());
            BestellenController controller = new BestellenController(agentPcSWinkelenMock.Object, agentPcSBestellenMock.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            var result = controller.GegevensInvoeren() as ViewResult;

            // Assert
            agentPcSWinkelenMock.Verify(agent => agent.GetWinkelmand(It.IsAny<string>()));

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.ViewBag.CountProduct);
        }

        [TestMethod]
        public void GegevensInvoerenPostTest()
        {
            // Arrange
            var agentPcSWinkelenMock = new Mock<IAgentPcSWinkelen>(MockBehavior.Strict);
            var agentPcSBestellenMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentPcSWinkelenMock.Setup(agent => agent.GetWinkelmand(It.IsAny<string>())).Returns(DummyData.GetWinkelmand());
            agentPcSBestellenMock.Setup(agent => agent.KlantGegevensInvoeren(It.IsAny<Klant>()));
            BestellenController controller = new BestellenController(agentPcSWinkelenMock.Object, agentPcSBestellenMock.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            var result = controller.GegevensInvoeren(DummyData.GetKlantVM()) as RedirectToRouteResult;

            // Assert
            agentPcSWinkelenMock.Verify(agent => agent.GetWinkelmand(It.IsAny<string>()));
            agentPcSBestellenMock.Verify(agent => agent.KlantGegevensInvoeren(It.IsAny<Klant>()));

            Assert.IsNotNull(result);
            Assert.AreEqual("ThankYou", result.RouteName);
        }


        [TestMethod]
        public void ThankYouPageTest()
        {
            // Arrange
            var agentPcSWinkelenMock = new Mock<IAgentPcSWinkelen>(MockBehavior.Strict);
            var agentPcSBestellenMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentPcSWinkelenMock.Setup(agent => agent.GetWinkelmand(It.IsAny<string>())).Returns(DummyData.GetWinkelmand());
            BestellenController controller = new BestellenController(agentPcSWinkelenMock.Object, agentPcSBestellenMock.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            var result = controller.ThankYouPage() as ViewResult;

            // Assert
            agentPcSWinkelenMock.Verify(agent => agent.GetWinkelmand(It.IsAny<string>()));

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.ViewBag.CountProduct);
        }
    }
}
