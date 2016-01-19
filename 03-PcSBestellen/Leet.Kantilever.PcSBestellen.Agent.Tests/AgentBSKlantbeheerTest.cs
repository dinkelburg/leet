using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Minor.ServiceBus.Agent.Implementation;
using Leet.Kantilever.BSKlantbeheer.V1;
using Leet.Kantilever.BSKlantbeheer.V1.Messages;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    [TestClass]
    public class AgentBSKlantbeheerTest
    {
        [TestMethod]
        public void GetKlant_FactoryCalledTest()
        {
            //Arrange
            var serviceMock = new Mock<IKlantbeheerService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.GetKlant(It.IsAny<GetKlantByKlantnummerRequestMessage>())).Returns(DummyData.GetGetKlantByKlantnummerResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IKlantbeheerService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSKlantbeheer agent = new AgentBSKlantbeheer(factoryMock.Object);

            //Act
            var klant = agent.GetKlant("Client01");

            //Assert
            serviceMock.Verify(service => service.GetKlant(It.IsAny<GetKlantByKlantnummerRequestMessage>()));
            factoryMock.Verify(factory => factory.CreateAgent());

            var expectedKlant = DummyData.GetGetKlantByKlantnummerResponseMessage().Klant;

            Assert.AreEqual(expectedKlant.ID, klant.ID);
            Assert.AreEqual(expectedKlant.Klantnummer, klant.Klantnummer);
            Assert.AreEqual(expectedKlant.Voornaam, klant.Voornaam);
            Assert.AreEqual(expectedKlant.Tussenvoegsel, klant.Tussenvoegsel);
            Assert.AreEqual(expectedKlant.Achternaam, klant.Achternaam);
            Assert.AreEqual(expectedKlant.Gebruikersnaam, klant.Gebruikersnaam);
            Assert.AreEqual(expectedKlant.Adresregel1, klant.Adresregel1);
            Assert.AreEqual(expectedKlant.Adresregel2, klant.Adresregel2);
            Assert.AreEqual(expectedKlant.Postcode, klant.Postcode);
            Assert.AreEqual(expectedKlant.Telefoonnummer, klant.Telefoonnummer);
            Assert.AreEqual(expectedKlant.Email, klant.Email);
            Assert.AreEqual(expectedKlant.Woonplaats, klant.Woonplaats);
        }

        [TestMethod]
        public void GetKlant_KlantnummerNullTest()
        {
            //Arrange
            var serviceMock = new Mock<IKlantbeheerService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.GetKlant(It.IsAny<GetKlantByKlantnummerRequestMessage>())).Returns(DummyData.GetGetKlantByKlantnummerResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IKlantbeheerService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSKlantbeheer agent = new AgentBSKlantbeheer(factoryMock.Object);

            //Act
            try
            {
                var klant = agent.GetKlant(null);
                //Assert
                Assert.Fail("ArgumentNullException not thrown when searching klant by null");
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual("Value cannot be null.\r\nParameter name: Klantnummer mag niet null zijn om een klant te zoeken", ex.Message);
            }
        }

        [TestMethod]
        public void GetKlant_KlantnummerEmptyTest()
        {
            //Arrange
            var serviceMock = new Mock<IKlantbeheerService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.GetKlant(It.IsAny<GetKlantByKlantnummerRequestMessage>())).Returns(DummyData.GetGetKlantByKlantnummerResponseMessage());
            var factoryMock = new Mock<ServiceFactory<IKlantbeheerService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSKlantbeheer agent = new AgentBSKlantbeheer(factoryMock.Object);

            //Act
            try
            {
                var klant = agent.GetKlant(string.Empty);
                //Assert
                Assert.Fail("ArgumentNullException not thrown when searching klant by null");
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.AreEqual("Value cannot be null.\r\nParameter name: Klantnummer mag niet null zijn om een klant te zoeken", ex.Message);
            }
        }

        [TestMethod]
        public void RegistreerKlant_FactoryCalledTest()
        {
            //Arrange
            var serviceMock = new Mock<IKlantbeheerService>(MockBehavior.Strict);
            serviceMock.Setup(service => service.RegistreerKlant(It.IsAny<InsertKlantGegevensRequestMessage>()));
            var factoryMock = new Mock<ServiceFactory<IKlantbeheerService>>(MockBehavior.Strict);
            factoryMock.Setup(factory => factory.CreateAgent()).Returns(serviceMock.Object);

            AgentBSKlantbeheer agent = new AgentBSKlantbeheer(factoryMock.Object);

            //Act
            agent.RegistreerKlant(It.IsAny<Klant>());

            //Assert
            serviceMock.Verify(service => service.RegistreerKlant(It.IsAny<InsertKlantGegevensRequestMessage>()));
            factoryMock.Verify(factory => factory.CreateAgent());
        }


    }
}
