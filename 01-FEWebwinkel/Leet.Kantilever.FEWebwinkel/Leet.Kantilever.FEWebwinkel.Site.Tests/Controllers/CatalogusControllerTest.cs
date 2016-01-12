using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEWebwinkel.Site.Controllers;
using System.Web.Mvc;
using Moq;
using Leet.Kantilever.FEWebwinkel.Agent;
using Leet.Kantilever.FEWebwinkel.Agent.Tests;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests.Controllers
{
    [TestClass]
    public class CatalogusControllerTest
    {
        [TestMethod]
        public void IndexWithoutPageTest()
        {
            // Arrange
            var agentBSCatalogusBeheerMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            agentBSCatalogusBeheerMock.Setup(agent => agent.FindProducts(It.IsAny<int?>())).Returns(DummyData.GetProductCollection());
            var agentPcSWinkelen = new Mock<IAgentPcSWinkelen>(MockBehavior.Strict);
            agentPcSWinkelen.Setup(agent => agent.GetWinkelmand(It.IsAny<string>())).Returns(DummyData.GetWinkelmand());


            CatalogusController controller = new CatalogusController(agentBSCatalogusBeheerMock.Object, agentPcSWinkelen.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            ViewResult result = controller.Index(null) as ViewResult;

            // Assert
            agentBSCatalogusBeheerMock.Verify(agent => agent.FindProducts(It.IsAny<int?>()));
            agentPcSWinkelen.Verify(agent => agent.GetWinkelmand(It.IsAny<string>()));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexWithPageTest()
        {
            // Arrange
            var agentBSCatalogusBeheerMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            agentBSCatalogusBeheerMock.Setup(agent => agent.FindProducts(It.IsAny<int?>())).Returns(DummyData.GetProductCollection());
            var agentPcSWinkelen = new Mock<IAgentPcSWinkelen>(MockBehavior.Strict);
            agentPcSWinkelen.Setup(agent => agent.GetWinkelmand(It.IsAny<string>())).Returns(DummyData.GetWinkelmand());

            CatalogusController controller = new CatalogusController(agentBSCatalogusBeheerMock.Object, agentPcSWinkelen.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            agentBSCatalogusBeheerMock.Verify(agent => agent.FindProducts(It.IsAny<int?>()));
            agentPcSWinkelen.Verify(agent => agent.GetWinkelmand(It.IsAny<string>()));
            Assert.IsNotNull(result);
        }
    }
}
