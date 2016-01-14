using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kantilever.BsCatalogusbeheer.V1;
using Kantilever.BsCatalogusbeheer.Messages.V1;
using Minor.ServiceBus.Agent.Implementation;
using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.FEWebwinkel.Agent.Tests
{
    [TestClass]
    public class AgentBSCatalogusBeheerTest
    {
        [TestMethod]
        public void FindAllProductsWithoutPageTest()
        {
            //Arrange
            var serviceMock = new Mock<ICatalogusBeheer>(MockBehavior.Strict);
            serviceMock.Setup(service => service.FindProducts(It.IsAny<MsgFindProductsRequest>())).Returns(DummyData.GetMsgFindProductsResult());
            var factoryMock = new Mock<ServiceFactory<ICatalogusBeheer>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer(factoryMock.Object);

            //Act
            var productCollection = agent.FindProducts(null);

            //Assert
            serviceMock.Verify(service => service.FindProducts(It.IsAny<MsgFindProductsRequest>()));
            factoryMock.Verify(factory => factory.CreateAgent());
            Assert.AreEqual(5, productCollection.Count);
            AssertProductCollection(productCollection, DummyData.GetProductCollection());
        }

        [TestMethod]
        public void FindAllProductsWithPageTest()
        {
            //Arrange
            var serviceMock = new Mock<ICatalogusBeheer>(MockBehavior.Strict);
            serviceMock.Setup(service => service.FindProducts(It.IsAny<MsgFindProductsRequest>())).Returns(DummyData.GetMsgFindProductsResult());
            var factoryMock = new Mock<ServiceFactory<ICatalogusBeheer>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer(factoryMock.Object);

            //Act
            var productCollection = agent.FindProducts(1);

            //Assert
            serviceMock.Verify(service => service.FindProducts(It.IsAny<MsgFindProductsRequest>()));
            factoryMock.Verify(factory => factory.CreateAgent());
            Assert.AreEqual(5, productCollection.Count);
            AssertProductCollection(productCollection, DummyData.GetProductCollection());
        }





        private static void AssertProductCollection(ProductCollection productCollection, ProductCollection expectedProductCollection)
        {
            for (int i = 0; i < productCollection.Count; i++)
            {
                Assert.AreEqual(expectedProductCollection[i].Id, productCollection[i].Id);
                Assert.AreEqual(expectedProductCollection[i].Naam, productCollection[i].Naam);
                Assert.AreEqual(expectedProductCollection[i].LeverancierNaam, productCollection[i].LeverancierNaam);
                Assert.AreEqual(expectedProductCollection[i].AfbeeldingURL, productCollection[i].AfbeeldingURL);
                Assert.AreEqual(expectedProductCollection[i].Prijs, productCollection[i].Prijs);
            }
        }
    }
}
