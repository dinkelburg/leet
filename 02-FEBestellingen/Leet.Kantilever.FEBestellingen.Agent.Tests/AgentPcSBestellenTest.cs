using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Minor.ServiceBus.Agent.Implementation;
using minorcase3pcsbestellen.v1.messages;
using minorcase3pcsbestellen.v1.schema;

namespace Leet.Kantilever.FEBestellingen.Agent.Tests
{
    [TestClass]
    public class AgentPcSBestellenTest
    {

        [TestMethod]
        public void FindAllBestellingen_Geeft1ProductTerugTest()
        {
            // Arrange
            var serviceMock = new Mock<IBestellenService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.FindAllBestellingen()).Returns(DummyData.GetAllBestellingenResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IBestellenService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);
            var agent = new AgentPcSBestellen(factoryMock.Object);

            // Act
            var bestellingCollection = agent.FindAllBestellingen();

            // Assert
            serviceMock.Verify(service => service.FindAllBestellingen());
            factoryMock.Verify(factory => factory.CreateAgent());

            Assert.AreEqual(1, bestellingCollection.Count);
            AssertBestellingCollection(bestellingCollection, DummyData.GetBestellingCollection());

        }

        [TestMethod]
        public void GetBestellingByID()
        {
            //arrange
            var serviceMock = new Mock<IBestellenService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.FindBestellingByBestelnummer(It.IsAny<GetBestellingByIDRequestMessage>())).Returns(DummyData.GetBestellingByIDResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IBestellenService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);
            var agent = new AgentPcSBestellen(factoryMock.Object);

            //act
            var bestelling = agent.FindBestellingByBestelnummer(1);

            //assert
            serviceMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<GetBestellingByIDRequestMessage>()));
            Assert.IsNotNull(bestelling.Klant);
            Assert.IsNotNull(bestelling);
        }

        private void AssertBestellingCollection(BestellingCollection actualBestellingCollection, BestellingCollection expectedBestellingCollection)
        {
            for (int i = 0; i < actualBestellingCollection.Count; i++)
            {
                Assert.AreEqual(expectedBestellingCollection[i].ID, actualBestellingCollection[i].ID);
                Assert.AreEqual(expectedBestellingCollection[i].Besteldatum, actualBestellingCollection[i].Besteldatum);
                Assert.AreEqual(expectedBestellingCollection[i].Bestelnummer, actualBestellingCollection[i].Bestelnummer);
                for (int j = 0; j < expectedBestellingCollection[i].BestellingsregelCollection.Count; j++)
                {
                    Assert.AreEqual(expectedBestellingCollection[i].BestellingsregelCollection[j].Product.Naam, actualBestellingCollection[i].BestellingsregelCollection[j].Product.Naam);
                    Assert.AreEqual(expectedBestellingCollection[i].BestellingsregelCollection[j].Product.LeveranciersProductId, actualBestellingCollection[i].BestellingsregelCollection[j].Product.LeveranciersProductId);
                    Assert.AreEqual(expectedBestellingCollection[i].BestellingsregelCollection[j].Aantal, actualBestellingCollection[i].BestellingsregelCollection[j].Aantal);

                }
            }
        }

        [TestMethod]
        public void FindVolgendeOpenBestelling_RoeptFindVolgendeOpenBestellingVanProxyAanTest()
        {
            //arrange
            var serviceMock = new Mock<IBestellenService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.FindVolgendeOpenBestelling()).Returns(new GetVolgendeOpenBestellingResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IBestellenService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);
            var agent = new AgentPcSBestellen(factoryMock.Object);

            //act
            agent.FindVolgendeOpenBestelling();

            //assert
            serviceMock.Verify(a => a.FindVolgendeOpenBestelling(), Times.Once());
        }
    }
}
