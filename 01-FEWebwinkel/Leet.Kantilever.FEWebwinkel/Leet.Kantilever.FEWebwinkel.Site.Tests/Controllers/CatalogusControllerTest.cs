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
            var mock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            mock.Setup(agent => agent.FindProducts(It.IsAny<int?>())).Returns(DummyData.GetProductCollection());
            CatalogusController controller = new CatalogusController(mock.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            ViewResult result = controller.Index(null) as ViewResult;

            // Assert
            mock.Verify(agent => agent.FindProducts(It.IsAny<int?>()));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexWithPageTest()
        {
            // Arrange
            var mock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            mock.Setup(agent => agent.FindProducts(It.IsAny<int?>())).Returns(DummyData.GetProductCollection());
            CatalogusController controller = new CatalogusController(mock.Object);
            controller.ControllerContext = Helper.CreateContext(controller);

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            mock.Verify(agent => agent.FindProducts(It.IsAny<int?>()));
            Assert.IsNotNull(result);
        }
    }
}
