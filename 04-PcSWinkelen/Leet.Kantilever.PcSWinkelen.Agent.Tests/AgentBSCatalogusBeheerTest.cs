using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kantilever.BsCatalogusbeheer.V1;
using Leet.Kantilever.PcSWinkelen.Contract;
using Moq;
using Kantilever.BsCatalogusbeheer.Messages.V1;
using Minor.ServiceBus.Agent.Implementation;
using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.PcSWinkelen.Agent.Tests
{
    [TestClass]
    public class AgentBSCatalogusBeheerTest
    {
        [TestMethod]
        public void FindProductByIdTest()
        {
            //Arrange
            var serviceMock = new Mock<ICatalogusBeheer>(MockBehavior.Strict);
            serviceMock.Setup(service => service.FindProductById(It.IsAny<MsgFindProductByIdRequest>())).Returns(DummyData.GetMsgFindProductByIdResult());
            var factoryMock = new Mock<ServiceFactory<ICatalogusBeheer>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer(factoryMock.Object);

            //Act
            var product = agent.FindProductById(1);

            //Assert
            serviceMock.Verify(service => service.FindProductById(It.IsAny<MsgFindProductByIdRequest>()));
            factoryMock.Verify(factory => factory.CreateAgent());
            AssertProduct(product, DummyData.GetProduct());
        }


        private static void AssertProduct(Product product, Product expectedProduct)
        {
            Assert.AreEqual(expectedProduct.Id, product.Id);
            Assert.AreEqual(expectedProduct.Naam, product.Naam);
            Assert.AreEqual(expectedProduct.LeverancierNaam, product.LeverancierNaam);
            Assert.AreEqual(expectedProduct.AfbeeldingURL, product.AfbeeldingURL);
            Assert.AreEqual(expectedProduct.Prijs, product.Prijs);
            Assert.AreEqual(expectedProduct.Beschrijving, product.Beschrijving);
            Assert.AreEqual(expectedProduct.LeverbaarVanaf, product.LeverbaarVanaf);
            Assert.AreEqual(expectedProduct.LeverbaarTot, product.LeverbaarTot);
            Assert.AreEqual(expectedProduct.LeveranciersProductId, product.LeveranciersProductId);
        }
    }
}
