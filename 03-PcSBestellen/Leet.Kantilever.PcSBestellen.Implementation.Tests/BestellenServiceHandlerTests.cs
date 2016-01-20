using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.PcSBestellen.Agent;
using KantileverAlias = Kantilever.BsCatalogusbeheer;
using Moq;
using System.Collections.Generic;

using System.Linq;
using Leet.Kantilever.PcSBestellen.V1.Messages;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Implementation.Tests
{
    [TestClass]
    public class BestellenServiceHandlerTests
    {
        [TestMethod]
        public void FindAllBestellingenCallsAgents()
        {
            // Arrange
            var BSBestellenMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var regels = new BSBestellingenbeheer.V1.Schema.BestellingsregelCollection();
            regels.Add(new BSBestellingenbeheer.V1.Schema.Bestellingsregel { Aantal = 1, Prijs = 105, ProductID = 1 });
            BSBestellenMock.Setup(m => m.GetAllBestellingen())
                .Returns(new List<BSBestellingenbeheer.V1.Schema.Bestelling>
                {
                   DummyData.BSBestellingbeheerBestelling
                })
                .Verifiable();
            
            var BSCatalogusMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            BSCatalogusMock.Setup(m => m.GetProductsById(It.IsAny<int[]>()))
                .Returns(DummyData.BSCatalogusProductList);

            var handler = new BestellenServiceHandler(BSBestellenMock.Object, BSCatalogusMock.Object, null, null);

            //Act
            handler.FindAllBestellingen();

            //Assert
            BSCatalogusMock.Verify(m => m.GetProductsById(It.IsAny<int[]>()), Times.Once);
            BSBestellenMock.Verify(m => m.GetAllBestellingen(), Times.Once);
        }

        [TestMethod]
        public void FindAllBestellingenReturnsAllBestellingen()
        {
            // Arrange
            var BSBestellenMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var regels = new BSBestellingenbeheer.V1.Schema.BestellingsregelCollection();
            regels.Add(new BSBestellingenbeheer.V1.Schema.Bestellingsregel { Aantal = 1, Prijs = 105, ProductID = 1 });

            var bestellingList = new List<BSBestellingenbeheer.V1.Schema.Bestelling>
                {
                    DummyData.BSBestellingbeheerBestelling
                };
            BSBestellenMock.Setup(m => m.GetAllBestellingen())
                .Returns(bestellingList)
                .Verifiable();

            var BSCatalogusMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            BSCatalogusMock.Setup(m => m.GetProductsById(new int[] { 1 }))
                .Returns(DummyData.BSCatalogusProductList);

            var handler = new BestellenServiceHandler(BSBestellenMock.Object, BSCatalogusMock.Object, null, null);

            //Act
            var result = handler.FindAllBestellingen();

            //Assert
                //Return type
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GetAllBestellingenResponseMessage));
                //Orders
            Assert.AreEqual(bestellingList.Count, result.BestellingCollection.Count);
            Assert.AreEqual(bestellingList.First().ID, result.BestellingCollection.First().ID);
                //OrderRegels
            Assert.AreEqual(bestellingList.Count, result.BestellingCollection.First().BestellingsregelCollection.Count);
            Assert.AreEqual(bestellingList.First().Bestellingsregels.First().Aantal, result.BestellingCollection.First().BestellingsregelCollection.First().Aantal);
                //Product
            Assert.AreEqual(DummyData.BSCatalogusProductList.First().Id, result.BestellingCollection.First().BestellingsregelCollection.First().Product.Id);
                    //Prijs
            Assert.AreEqual(DummyData.BSCatalogusProductList.First().Prijs, result.BestellingCollection.First().BestellingsregelCollection.First().Product.Prijs);
                    //Productnaam
            Assert.AreEqual(DummyData.BSCatalogusProductList.First().Naam, result.BestellingCollection.First().BestellingsregelCollection.First().Product.Naam);
                    //Leveranciernaam
            Assert.AreEqual(DummyData.BSCatalogusProductList.First().LeverancierNaam, result.BestellingCollection.First().BestellingsregelCollection.First().Product.LeverancierNaam);

            Assert.AreEqual(DummyData.BSCatalogusProductList.First().LeveranciersProductId, result.BestellingCollection.First().BestellingsregelCollection.First().Product.LeveranciersProductId);
            Assert.AreEqual(DummyData.BSCatalogusProductList.First().LeverbaarVanaf, result.BestellingCollection.First().BestellingsregelCollection.First().Product.LeverbaarVanaf);
        }

        [TestMethod]
        public void CreateBestelling_CallsAgentsTest()
        {
            // Arrange
            var agentWinkelenMock = new Mock<IAgentPcSWinkelen>(MockBehavior.Strict);
            var agentBestellenMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var agentKlantMock = new Mock<IAgentBSKlantbeheer>(MockBehavior.Strict);

            agentWinkelenMock.Setup(a => a.GetWinkelMand("1552fc72-2d19-44e5-ad06-efe175cb51fd"))
                .Returns(DummyData.PcSWinkelenWinkelmand);
            agentWinkelenMock.Setup(a => a.RemoveWinkelmand("1552fc72-2d19-44e5-ad06-efe175cb51fd"));
            agentBestellenMock.Setup(a => a.CreateBestelling(It.IsAny<BSBestellingenbeheer.V1.Schema.Bestelling>()));
            agentKlantMock.Setup(a => a.RegistreerKlant(It.IsAny<Klant>()));

            var handler = new BestellenServiceHandler(agentBestellenMock.Object, null, agentWinkelenMock.Object, agentKlantMock.Object);
            var message = new CreateBestellingRequestMessage { Klant = DummyData.Klant };

            // Act
            handler.CreateBestelling(message);

            // Assert
            agentWinkelenMock.Verify(a => a.GetWinkelMand("1552fc72-2d19-44e5-ad06-efe175cb51fd"), Times.Once);
            agentBestellenMock.Verify(a => a.CreateBestelling(It.IsAny<BSBestellingenbeheer.V1.Schema.Bestelling>()), Times.Once);
            agentWinkelenMock.Verify(a => a.RemoveWinkelmand("1552fc72-2d19-44e5-ad06-efe175cb51fd"), Times.Once);
            agentKlantMock.Verify(a => a.RegistreerKlant(It.IsAny<Klant>()), Times.Once);
        }

        [TestMethod]
        public void FindVolgendeOpenBestelling_CallsAgentTest()
        {
            var agentBestellingMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var agentCatalogusMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);

            agentCatalogusMock.Setup(a => a.GetProductsById(It.IsAny<int[]>()))
                .Returns(DummyData.BSCatalogusProductList);

            agentBestellingMock.Setup(a => a.GetVolgendeBestelling())
                .Returns(DummyData.BSBestellingbeheerBestelling);
            var handler = new BestellenServiceHandler(agentBestellingMock.Object, agentCatalogusMock.Object, null, null);

            // Act
            handler.FindVolgendeOpenBestelling();

            // Assert
            agentBestellingMock.Verify(a => a.GetVolgendeBestelling(), Times.Once);
        }

        [TestMethod]
        public void FindBestellingById_CallsAgentsTest()
        {
            // Arrange
            var agentBestellingMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var agentCatalogusMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            var agentKlantMock = new Mock<IAgentBSKlantbeheer>(MockBehavior.Strict);

            agentCatalogusMock.Setup(a => a.GetProductsById(It.IsAny<int[]>()))
                .Returns(DummyData.BSCatalogusProductList);

                //Setup
            agentBestellingMock.Setup(a => a.GetVolgendeBestelling())
                .Returns(DummyData.BSBestellingbeheerBestelling);
            agentBestellingMock.Setup(a => a.GetBestellingByBestelnummer(DummyData.BSBestellingbeheerBestelling.ID))
                .Returns(DummyData.BSBestellingbeheerBestelling);
            agentKlantMock.Setup(a => a.GetKlant(It.IsAny<string>())).Returns(DummyData.BsKlant);
            var handler = new BestellenServiceHandler(agentBestellingMock.Object, agentCatalogusMock.Object, null, agentKlantMock.Object);

            // Act
            handler.FindBestellingByBestelnummer(new GetBestellingByIDRequestMessage { BestellingsID = DummyData.BSBestellingbeheerBestelling.ID });

            // Assert
            agentBestellingMock.Verify(a => a.GetBestellingByBestelnummer(DummyData.BSBestellingbeheerBestelling.ID), Times.Once);
            agentCatalogusMock.Verify(a => a.GetProductsById(It.IsAny<int[]>()));
            agentKlantMock.Verify(a => a.GetKlant(It.IsAny<string>()));
        }

        [TestMethod]
        public void UpdateBestelling_CallsAgentBestellingen()
        {
            // Arrange
            var mockAgent = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var handler = new BestellenServiceHandler(mockAgent.Object,null,null, null);

            var bestelling = DummyData.BSBestellingbeheerBestelling;

            mockAgent.Setup(a => a.UpdateBestelling(It.IsAny<BSBestellingenbeheer.V1.Schema.Bestelling>()));



            // Act
            handler.UpdateBestelling(new UpdateBestellingRequestMessage { Bestelling = DummyData.PcSBestellenBestelling });

            // Assert
            mockAgent.Verify(a => a.UpdateBestelling(It.IsAny<BSBestellingenbeheer.V1.Schema.Bestelling>()), Times.Once);

        }


        [TestMethod]
        public void BepaalStatusVoorBestelling_BestellingUnderLimiet()
        {
            // Arrange
            V1.Schema.Bestelling bestelling = DummyData.PcSBestellenBestelling;
            var klant = DummyData.Klant;
            var handler = new BestellenServiceHandler();

            // Act
            var result = handler.BepaalStatusVoorBestelling(bestelling, klant);

            // Assert
            Assert.AreEqual(minorcase3bsbestellingenbeheer.v1.schema.Bestellingsstatus.Goedgekeurd, result);
        }
    }
}
