using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using Leet.Kantilever.PcSWinkelen.DAL;
using Leet.Kantilever.PcSWinkelen.Agent;
using Leet.Kantilever.PcSWinkelen.Agent.Tests;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel;
using Minor.case3.Leet.V1.FunctionalError;

namespace Leet.Kantilever.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class WinkelenServiceHandlerTest
    {


        [TestMethod]
        public void VoegProductToeTest()
        {
            // Arrange
            var mapperMock = new Mock<IDataMapper<Winkelmand>>(MockBehavior.Strict);
            mapperMock.Setup(mapper => mapper.AddProductToWinkelmand(It.IsAny<Product>(), It.IsAny<string>()));
            mapperMock.Setup(mapper => mapper.FindWinkelmandByClientId(It.IsAny<string>())).Returns(DummyDataDAL.GetWinkelmand());

            var agentMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.FindProductById(It.IsAny<int>())).Returns(DummyData.GetProduct());
            WinkelenServiceHandler handler = new WinkelenServiceHandler(mapperMock.Object, agentMock.Object);

            // Act
            var respMessage = handler.VoegProductToe(DummyData.GetToevoegenWinkelmandRequestMessage());

            // Assert
            mapperMock.Verify(mapper => mapper.AddProductToWinkelmand(It.IsAny<Product>(), It.IsAny<string>()));
            mapperMock.Verify(mapper => mapper.FindWinkelmandByClientId(It.IsAny<string>()));
            agentMock.Verify(agent => agent.FindProductById(It.IsAny<int>()));

            Assert.AreEqual(2, respMessage.Winkelmand.Count);
        }


        [TestMethod]
        public void GetWinkelmandjeTest()
        {
            // Arrange
            var mapperMock = new Mock<IDataMapper<Winkelmand>>(MockBehavior.Strict);
            mapperMock.Setup(mapper => mapper.FindWinkelmandByClientId(It.IsAny<string>())).Returns(DummyDataDAL.GetWinkelmand());

            WinkelenServiceHandler handler = new WinkelenServiceHandler(mapperMock.Object, null);

            // Act
            var respMessage = handler.GetWinkelmandje(DummyData.GetVraagWinkelmandRequestMessage());

            // Assert
            mapperMock.Verify(mapper => mapper.FindWinkelmandByClientId(It.IsAny<string>()));

            Assert.AreEqual(2, respMessage.Winkelmand.Count);
        }

        [TestMethod]
        public void GetWinkelmandjeWithClientIDThatNotExistsTest()
        {
            // Arrange
            var mapperMock = new Mock<IDataMapper<Winkelmand>>(MockBehavior.Strict);
            mapperMock.Setup(mapper => mapper.FindWinkelmandByClientId(It.IsAny<string>())).Returns(default(Winkelmand));
            bool exceptionThrown = false;
            FunctionalErrorList errorlist = new FunctionalErrorList();

            WinkelenServiceHandler handler = new WinkelenServiceHandler(mapperMock.Object, null);

            try {
                // Act
                var respMessage = handler.GetWinkelmandje(DummyData.GetVraagWinkelmandRequestMessage());
            }
            catch (FaultException<FunctionalErrorList> ex)
            {
                errorlist = ex.Detail;
                exceptionThrown = true;
            }
            // Assert
            mapperMock.Verify(mapper => mapper.FindWinkelmandByClientId(It.IsAny<string>()));

            Assert.IsTrue(exceptionThrown);
            Assert.AreEqual(1, errorlist.Count);
            Assert.AreEqual("Er is geen winkelmandje beschikbaar met het clientID Client01", errorlist.First().Message);
        }


        [TestMethod]
        public void RemoveWinkelmandTest()
        {
            // Arrange
            var mapperMock = new Mock<IDataMapper<Winkelmand>>(MockBehavior.Strict);
            mapperMock.Setup(mapper => mapper.RemoveWinkelmandByClientID(It.IsAny<string>()));

            var agentMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.FindProductById(It.IsAny<int>())).Returns(DummyData.GetProduct());
            WinkelenServiceHandler handler = new WinkelenServiceHandler(mapperMock.Object, agentMock.Object);

            // Act
            handler.RemoveWinkelmand(DummyData.GetVraagWinkelmandRequestMessage());

            // Assert
            mapperMock.Verify(mapper => mapper.RemoveWinkelmandByClientID(It.IsAny<string>()));
        }
    }
}
