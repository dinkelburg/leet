using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Minor.ServiceBus.Agent.Implementation;
using Kantilever.BsCatalogusbeheer.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using Kantilever.BsCatalogusbeheer.Messages.V1;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    [TestClass]
    public class AgentTests
    {
        [TestMethod]
        public void TestGetProductsById()
        {
            // Arrange
            var agentMock = new Mock<ICatalogusBeheer>(MockBehavior.Strict);
            agentMock.Setup(x => x.FindProductById(It.IsAny<MsgFindProductByIdRequest>())).Returns(DummyData.GetMsgFindProductByIdResult);
            var serviceMock = new Mock<ServiceFactory<ICatalogusBeheer>>(MockBehavior.Strict);
            serviceMock.Setup(x => x.CreateAgent()).Returns(agentMock.Object);
            
            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer(serviceMock.Object);
            List<Product> result = new List<Product>();
            // Act
            try
            {
                result.AddRange(agent.GetProductsById(new int[] { 123, 456, 24321 }));
            }
            // Assert
            catch (Exception e)
            {
                Assert.Fail("Ophalen van producten faalde met de volgende parameters:", e);
            }

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestGetNonExistingProduct()
        {
            // Arrange
            var agentMock = new Mock<ICatalogusBeheer>(MockBehavior.Strict);
            agentMock.Setup(x => x.FindProductById(It.IsAny<MsgFindProductByIdRequest>())).Returns(new MsgFindProductByIdResult { Succes = false });
            var serviceMock = new Mock<ServiceFactory<ICatalogusBeheer>>(MockBehavior.Strict);
            serviceMock.Setup(x => x.CreateAgent()).Returns(agentMock.Object);

            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer(serviceMock.Object);

            // Act
            try
            {
                var product = agent.GetProductsById(new int[] { 1 });
                Assert.Fail();
            }
            // Assert
            catch (Exception)
            {
                // Test succeeded if this path is taken.
            }            
        }
    }
}
