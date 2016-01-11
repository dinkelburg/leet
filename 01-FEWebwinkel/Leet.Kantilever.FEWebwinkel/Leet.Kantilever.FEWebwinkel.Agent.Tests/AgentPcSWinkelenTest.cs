using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using minorcase3pcswinkelen.v1.messages;
using Minor.ServiceBus.Agent.Implementation;
using BSCatalogusBeheer = schemaswwwkantilevernl.bscatalogusbeheer.product.v1;
using System.Linq;

namespace Leet.Kantilever.FEWebwinkel.Agent.Tests
{
    [TestClass]
    public class AgentPcSWinkelenTest
    {
        [TestMethod]
        public void VoegProductToeAanWinkelmandTest()
        {
            //Arrange
            var serviceMock = new Mock<IWinkelenService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.VoegProductToe(It.IsAny<ToevoegenWinkelmandRequestMessage>())).Returns(DummyData.GetWinkelmandResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IWinkelenService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentPcSWinkelen agent = new AgentPcSWinkelen(factoryMock.Object);

            //Act
            var winkelmand = agent.VoegProductToeAanWinkelmand(1, 1, "Client01");

            //Assert
            serviceMock.Verify(service => service.VoegProductToe(It.IsAny<ToevoegenWinkelmandRequestMessage>()));
            factoryMock.Verify(factory => factory.CreateAgent());

            Assert.AreEqual(1, winkelmand.Count);
            AssertProduct(winkelmand.First().Product, DummyData.GetWinkelmandResponseMessage().Winkelmand.First().Product);
        }

        [TestMethod]
        public void GetWinkelmandTest()
        {
            //Arrange
            var serviceMock = new Mock<IWinkelenService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.GetWinkelmandje(It.IsAny<VraagWinkelmandRequestMessage>())).Returns(DummyData.GetWinkelmandResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IWinkelenService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentPcSWinkelen agent = new AgentPcSWinkelen(factoryMock.Object);

            //Act
            var winkelmand = agent.GetWinkelmand("Client01");

            //Assert
            serviceMock.Verify(service => service.GetWinkelmandje(It.IsAny<VraagWinkelmandRequestMessage>()));
            factoryMock.Verify(factory => factory.CreateAgent());

            Assert.AreEqual(1, winkelmand.Count);
            AssertProduct(winkelmand.First().Product, DummyData.GetWinkelmandResponseMessage().Winkelmand.First().Product);
        }


        private static void AssertProduct(BSCatalogusBeheer.Product product, BSCatalogusBeheer.Product expextedProduct)
        {
            Assert.AreEqual(expextedProduct.AfbeeldingURL, product.AfbeeldingURL);
            Assert.AreEqual(expextedProduct.Beschrijving, product.Beschrijving);
            Assert.AreEqual(expextedProduct.LeverancierNaam, product.LeverancierNaam);
            Assert.AreEqual(expextedProduct.LeveranciersProductId, product.LeveranciersProductId);
            Assert.AreEqual(expextedProduct.LeverbaarTot, product.LeverbaarTot);
            Assert.AreEqual(expextedProduct.LeverbaarVanaf, product.LeverbaarVanaf);
            Assert.AreEqual(expextedProduct.Naam, product.Naam);
            Assert.AreEqual(expextedProduct.Prijs, product.Prijs);
        }
    }
}
