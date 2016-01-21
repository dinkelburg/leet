﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEBestellingen.Site.Controllers;
using Leet.Kantilever.FEBestellingen.Agent;
using Moq;
using System.Web.Mvc;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.ServiceModel;
using System.Linq;
using PcSBestellen = minorcase3pcsbestellen.v1.schema;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using System.Collections.Generic;

namespace Leet.Kantilever.FEBestellingen.Site.Tests.Controllers
{
    [TestClass]
    public class BetalingControllerTests
    {
        [TestMethod]
        public void ZoekOpBestelnummer_Get()
        {
            //arrange
            var controller = new BetalingController(null);

            //act
            var viewResult = controller.ZoekFactuurOpBestelnummer() as ViewResult;

            //assert
            Assert.IsNotNull(viewResult);
        }

        [TestMethod]
        public void ZoekOpBestelnummer_BackendCalled()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(DummyData.GetBestelling());
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.ZoekFactuurOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert

            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("Testdummy", factuur.Klant.Voornaam);
            Assert.AreEqual(1, factuur.Bestelling.Bestelnummer);
            Assert.AreEqual(2, factuur.Bestelling.Bestellingsregels.Count);
        }

        [TestMethod]
        public void ZoekOpBestelnummerBestellingsstatusGeweigerd_AddModelError()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            var bestelling = DummyData.GetBestelling();
            bestelling.Status = (int)Bestellingsstatus.Geweigerd;
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(bestelling);
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.ZoekFactuurOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("De factuur met het bestelnummer 1 heeft niet de juiste status om goedgekeurd te kunnen worden.", controller.ModelState["bestelnummer"].Errors.First().ErrorMessage);
        }

        [TestMethod]
        public void ZoekOpBestelnummerBestellingsstatusAlreadyBetaald_AddModelError()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            var bestelling = DummyData.GetBestelling();
            bestelling.Status = (int)Bestellingsstatus.Betaald;
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(bestelling);
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.ZoekFactuurOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("De factuur met het bestelnummer 1 heeft niet de juiste status om goedgekeurd te kunnen worden.", controller.ModelState["bestelnummer"].Errors.First().ErrorMessage);
        }

        [TestMethod]
        public void ZoekOpBestelnummerBackendThrowsFaultException_AddedModelError()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Throws(new FaultException());
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.ZoekFactuurOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("De factuur met het bestelnummer 1 is niet gevonden in het systeem", controller.ModelState["bestelnummer"].Errors.First().ErrorMessage);
        }

        [TestMethod]
        public void ZoekOpBestelnummer0_AddedModelError()
        {
            //arrange
            var controller = new BetalingController(null);

            //act
            var viewResult = controller.ZoekFactuurOpBestelnummer(0) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            Assert.AreEqual("Het bestelnummer moet minimaal 1 zijn", controller.ModelState["bestelnummer"].Errors.First().ErrorMessage);
        }


        [TestMethod]
        public void RegistreerBetaling_BackendCalled()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(DummyData.GetBestelling());
            agentMock.Setup(a => a.UpdateBestelling(It.IsAny<PcSBestellen.Bestelling>()));
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.RegistreerBetaling(1) as ViewResult;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            agentMock.Verify(a => a.UpdateBestelling(It.IsAny<PcSBestellen.Bestelling>()), Times.Once);
            Assert.AreEqual(1L, viewResult.Model);
        }

        [TestMethod]
        public void ShowListOfNieuweBestellingen_BackendCalled1Bestelling()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindAllNewBestellingen()).Returns(DummyData.GetBestellingList());
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.ShowListOfNieuweBestellingen() as ViewResult;

            //assert
            agentMock.Verify(m => m.FindAllNewBestellingen(), Times.Once);
            var bestellingVM = viewResult.Model as IEnumerable<BestellingListVM>;
            Assert.AreEqual(1, bestellingVM.Count());
        }

        [TestMethod]
        public void ShowListOfNieuweBestellingen_BackendCalled0Bestellingen()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindAllNewBestellingen()).Returns(new List<PcSBestellen.Bestelling>());
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.ShowListOfNieuweBestellingen() as ViewResult;

            //assert
            agentMock.Verify(m => m.FindAllNewBestellingen(), Times.Once);
            var bestellingVMList = viewResult.Model as IEnumerable<BestellingListVM>;
            Assert.AreEqual(0, bestellingVMList.Count());
        }

        [TestMethod]
        public void GetBestellingOpBestelnummerWithStatusNieuw_ReturnsFactuur_BestellingGoedkeurenView()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(DummyData.GetBestelling());
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.GetBestellingOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("Testdummy", factuur.Klant.Voornaam);
            Assert.AreEqual(1, factuur.Bestelling.Bestelnummer);
            Assert.AreEqual(2, factuur.Bestelling.Bestellingsregels.Count);
            Assert.AreEqual("Factuur_BestellingGoedkeuren", viewResult.ViewName);
        }

        [TestMethod]
        public void GetBestellingOpBestelnummerWithStatusGoedgekeurd_ReturnsShowListOfNieuweBestellingenView()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            var bestelling = DummyData.GetBestelling();
            bestelling.Status = (int)Bestellingsstatus.Goedgekeurd;
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(bestelling);
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.GetBestellingOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("ShowListOfNieuweBestellingen", viewResult.ViewName);
        }

        [TestMethod]
        public void GetBestellingOpBestelnummerThrowsFaultException_ReturnsShowListOfNieuweBestellingenView()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Throws(new FaultException());
            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.GetBestellingOpBestelnummer(1) as ViewResult;
            var factuur = viewResult.Model as FactuurVM;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            Assert.AreEqual("ShowListOfNieuweBestellingen", viewResult.ViewName);
        }

        [TestMethod]
        public void BestellingGoedkeuren_ReturnsView()
        {
            //arrange
            var agentMock = new Mock<IAgentPcSBestellen>(MockBehavior.Strict);
            var bestelling = DummyData.GetBestelling();
            agentMock.Setup(a => a.FindBestellingByBestelnummer(It.IsAny<long>())).Returns(bestelling);
            agentMock.Setup(a => a.UpdateBestelling(bestelling));

            var controller = new BetalingController(agentMock.Object);

            //act
            var viewResult = controller.BestellingGoedkeuren(1) as ViewResult;

            //assert
            agentMock.Verify(m => m.FindBestellingByBestelnummer(It.IsAny<long>()), Times.Once);
            agentMock.Verify(a => a.UpdateBestelling(bestelling), Times.Once);

            Assert.AreEqual(1L, viewResult.Model);
        }
    }
}