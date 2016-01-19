using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Minor.ServiceBus.Agent.Implementation;
using Leet.Kantilever.BSBestellingenbeheer.V1;
using Leet.Kantilever.BSBestellingenbeheer.V1.Messages;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    [TestClass]
    public class AgentBSBestellingenbeheerTest
    {
        [TestMethod]
        public void GetBestellingByBestelnummer_CallsAgent()
        {
            // Arrange
            var mockAgent = new Mock<ServiceFactory<IBestellingenbeheerService>>(MockBehavior.Strict);
            var mockProxy = new Mock<IBestellingenbeheerService>(MockBehavior.Strict);

            mockAgent.Setup(f => f.CreateAgent())
                .Returns(mockProxy.Object);
            mockProxy.Setup(p => p.FindBestelling(It.IsAny<GetBestellingByBestelnummerRequestMessage>()))
                .Returns(new GetBestellingByBestelnummerResponseMessage { Bestelling = new BSBestellingenbeheer.V1.Schema.Bestelling()});

            var agent = new BSBestellingenbeheerAgent(mockAgent.Object);

            // Act
            agent.GetBestellingByBestelnummer(123);

            // Assert
            mockAgent.Verify(a => a.CreateAgent(), Times.Once);
            mockProxy.Verify(p => p.FindBestelling(It.IsAny<GetBestellingByBestelnummerRequestMessage>()),Times.Once);
        }

        [TestMethod]
        public void UpdateBestellingCallsAgent()
        {
            // Arrange
            var mockAgent = new Mock<ServiceFactory<IBestellingenbeheerService>>(MockBehavior.Strict);
            var mockProxy = new Mock<IBestellingenbeheerService>(MockBehavior.Strict);

            mockAgent.Setup(f => f.CreateAgent())
                .Returns(mockProxy.Object);

            mockProxy.Setup(p => p.UpdateBestelling(It.IsAny<UpdateBestellingRequestMessage>()));

            var agent = new BSBestellingenbeheerAgent(mockAgent.Object);

            // Act
            agent.UpdateBestelling(new BSBestellingenbeheer.V1.Schema.Bestelling());

            // Assert
            mockProxy.Verify(p => p.UpdateBestelling(It.IsAny<UpdateBestellingRequestMessage>()), Times.Once);
        }
    }
}
