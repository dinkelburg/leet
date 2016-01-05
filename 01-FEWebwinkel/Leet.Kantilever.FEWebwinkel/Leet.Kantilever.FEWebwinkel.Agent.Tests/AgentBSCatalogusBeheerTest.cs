using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kantilever.BsCatalogusbeheer.V1;
using Kantilever.BsCatalogusbeheer.Messages.V1;
using Minor.ServiceBus.Agent.Implementation;

namespace Leet.Kantilever.FEWebwinkel.Agent.Tests
{
    [TestClass]
    public class AgentBSCatalogusBeheerTest
    {
        [TestMethod]
        public void FindAllProductsWithoutPage()
        {
            ////Arrange
            //var serviceMock = new Mock<ICatalogusBeheer>(MockBehavior.Strict);
            //serviceMock.Setup(service => service.FindProducts(It.IsAny<MsgFindProductsRequest>())).Returns(DummyData.GetMsgFindProductsResult());
            //var factoryMock = new Mock<ServiceFactory<ICatalogusBeheer>>(MockBehavior.Strict);
            //factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            //AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer(factoryMock.Object);

            ////Act
            //var productCollection = agent.FindAllProducts(null);

            ////Assert
            //Assert.AreEqual(1, productCollection.Count);
        }
    }
}
