using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Minor.ServiceBus.Agent.Implementation;
using System.Collections.Generic;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    [TestClass]
    public class AgentPcSWinkelenTest
    {
        [TestMethod]
        public void GetWinkelmand_AgentCalledTest()
        {
            // Arrange
            var facMock = new Mock<ServiceFactory<IWinkelenService>>(MockBehavior.Strict);
            var proxyMock = new Mock<IWinkelenService>(MockBehavior.Strict);
            
            facMock.Setup(f => f.CreateAgent())
                .Returns(proxyMock.Object);

            proxyMock.Setup(p => p.GetWinkelmandje(It.IsAny<PcSWinkelen.V1.Messages.VraagWinkelmandRequestMessage>()))
                .Returns(new PcSWinkelen.V1.Messages.WinkelmandResponseMessage());

            var agent = new AgentPcSWinkelen(facMock.Object);

            // Act
            agent.GetWinkelMand("db6ca229-3e5d-4b51-9588-a0f9dbba42d4");

            facMock.Verify(f => f.CreateAgent(),Times.Once);
            proxyMock.Verify(p => p.GetWinkelmandje(It.IsAny<PcSWinkelen.V1.Messages.VraagWinkelmandRequestMessage>()), Times.Once);
        }

        [TestMethod]
        public void GetWinkelmand_ReturnsCorrectWinkelmandTest()
        {
            // Arrange
            var facMock = new Mock<ServiceFactory<IWinkelenService>>(MockBehavior.Strict);
            var proxyMock = new Mock<IWinkelenService>(MockBehavior.Strict);

            facMock.Setup(f => f.CreateAgent())
                .Returns(proxyMock.Object);

            //Create winkelmand
            var winkelmandReturnmessage = new PcSWinkelen.V1.Messages.WinkelmandResponseMessage();
            winkelmandReturnmessage.Winkelmand = new PcSWinkelen.V1.Schema.Winkelmand();
            winkelmandReturnmessage.Winkelmand.AddRange(new List<PcSWinkelen.V1.Schema.WinkelmandRegel>
            {
                new PcSWinkelen.V1.Schema.WinkelmandRegel
                {
                    Aantal = 2,
                    Product = new BSCatalogusbeheer.V1.Product.Product
                    {
                        AfbeeldingURL = "product1.jpg",
                        Beschrijving = "Fiets",
                        Id = 245,
                        LeverancierNaam = "Batabus",
                        LeveranciersProductId = "btv22102441",
                        LeverbaarTot = new DateTime(2017,09,20),
                        LeverbaarVanaf = new DateTime(2005,04,13),
                        Naam = "Batuvus fiets",
                        Prijs = 1500
                    }
                }
            });
            proxyMock.Setup(p => p.GetWinkelmandje(It.IsAny<PcSWinkelen.V1.Messages.VraagWinkelmandRequestMessage>()))
                .Returns(winkelmandReturnmessage);

            

            var agent = new AgentPcSWinkelen(facMock.Object);

            // Act
            var result = agent.GetWinkelMand("db6ca229-3e5d-4b51-9588-a0f9dbba42d4");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, winkelmandReturnmessage.Winkelmand);
        }

        [TestMethod]
        public void RemoveWinkelmand_CallsAgentTest()
        {
            // Arrange
            var factoryMock = new Mock<ServiceFactory<IWinkelenService>>(MockBehavior.Strict);
            var proxyMock = new Mock<IWinkelenService>(MockBehavior.Strict);
            

            proxyMock.Setup(p => p.RemoveWinkelmand(It.IsAny<PcSWinkelen.V1.Messages.VraagWinkelmandRequestMessage>()));

            factoryMock.Setup(f => f.CreateAgent())
                .Returns(proxyMock.Object);

            var agent = new AgentPcSWinkelen(factoryMock.Object);

            // Act
            agent.RemoveWinkelmand("Client01");

            // Assert
            factoryMock.Verify(f => f.CreateAgent(), Times.Once);
            proxyMock.Verify(p => p.RemoveWinkelmand(It.IsAny<PcSWinkelen.V1.Messages.VraagWinkelmandRequestMessage>()), Times.Once);
        }
    }
}
