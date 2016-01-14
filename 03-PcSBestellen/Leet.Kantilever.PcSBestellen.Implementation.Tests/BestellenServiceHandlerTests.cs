using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.PcSBestellen.Agent;
using KantileverAlias = Kantilever.BsCatalogusbeheer;
using Moq;
using System.Collections.Generic;

using System.Linq;
using Leet.Kantilever.PcSBestellen.V1.Messages;

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
                    #region Return data
                    new BSBestellingenbeheer.V1.Schema.Bestelling
                    {
                        Besteldatum = new DateTime(2015,1,3),
                        Bestelnummer = 3264,
                        ID = 124,
                        KlantID = 124,
                        Bestellingsregels = regels
                    }
                    #endregion
                })
                .Verifiable();
            
            var BSCatalogusMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            BSCatalogusMock.Setup(m => m.GetProductsById(new int[] { 1 }))
                .Returns(
            #region Return data
                new List<KantileverAlias.Product.V1.Product> {
                    new KantileverAlias.Product.V1.Product
                    {
                        AfbeeldingURL = "product.jpg",
                        Beschrijving = "Blauwe fiets",
                        Id = 1,
                        LeverancierNaam = "De boer fietsen",
                        LeveranciersProductId = "DBF15432",
                        LeverbaarVanaf = new DateTime(2010,4,6),
                        Naam = "Batavus sport blauw",
                        Prijs = 945,
                        CategorieLijst = new KantileverAlias.Categorie.V1.CategorieCollection(),
                    }
                }
                #endregion
            );
            var handler = new BestellenServiceHandler(BSBestellenMock.Object, BSCatalogusMock.Object, null);

            //Act
            handler.FindAllBestellingen();

            //Assert
            BSCatalogusMock.Verify(m => m.GetProductsById(new int[] { 1 }), Times.Once);
            BSBestellenMock.Verify(m => m.GetAllBestellingen(), Times.Once);
        }

        [TestMethod]
        public void FindAllBestellingenReturnsAllBestellingen()
        {
            // Arrange
            var BSBestellenMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            var regels = new BSBestellingenbeheer.V1.Schema.BestellingsregelCollection();
            regels.Add(new BSBestellingenbeheer.V1.Schema.Bestellingsregel { Aantal = 1, Prijs = 105, ProductID = 1 });
            BSBestellenMock.Setup(m => m.GetAllBestellingen())
                .Returns(new List<BSBestellingenbeheer.V1.Schema.Bestelling>
                {
                    #region Return data
                    new BSBestellingenbeheer.V1.Schema.Bestelling
                    {
                        Besteldatum = new DateTime(2015,1,3),
                        Bestelnummer = 3264,
                        ID = 124,
                        KlantID = 124,
                        Bestellingsregels = regels
                    }
                    #endregion
                })
                .Verifiable();

            var BSCatalogusMock = new Mock<IAgentBSCatalogusBeheer>(MockBehavior.Strict);
            BSCatalogusMock.Setup(m => m.GetProductsById(new int[] { 1 }))
                .Returns(
            #region Return data
                new List<KantileverAlias.Product.V1.Product> {
                    new KantileverAlias.Product.V1.Product
                    {
                        AfbeeldingURL = "product.jpg",
                        Beschrijving = "Blauwe fiets",
                        Id = 1,
                        CategorieLijst = new KantileverAlias.Categorie.V1.CategorieCollection(),
                        LeverancierNaam = "De boer fietsen",
                        LeveranciersProductId = "DBF15432",
                        LeverbaarVanaf = new DateTime(2010,4,6),
                        Naam = "Batavus sport blauw",
                        Prijs = 945,
                    }
                }
                #endregion
            );
            var handler = new BestellenServiceHandler(BSBestellenMock.Object, BSCatalogusMock.Object, null);

            //Act
            var result = handler.FindAllBestellingen();

            //Assert
                //Return type
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GetAllBestellingenResponseMessage));
                //Orders
            Assert.AreEqual(result.BestellingCollection.Count, 1);
            Assert.AreEqual(result.BestellingCollection.First().ID, 124M);
                //OrderRegels
            Assert.AreEqual(1, result.BestellingCollection.First().BestellingsregelCollection.Count);
            Assert.AreEqual(1, result.BestellingCollection.First().BestellingsregelCollection.First().Aantal);
                //Product
            Assert.AreEqual(1,result.BestellingCollection.First().BestellingsregelCollection.First().Product.Id);
            Assert.AreEqual(105,result.BestellingCollection.First().BestellingsregelCollection.First().Product.Prijs);
            Assert.AreEqual("Batavus sport blauw", result.BestellingCollection.First().BestellingsregelCollection.First().Product.Naam);
            Assert.AreEqual("De boer fietsen", result.BestellingCollection.First().BestellingsregelCollection.First().Product.LeverancierNaam);
            Assert.AreEqual("DBF15432", result.BestellingCollection.First().BestellingsregelCollection.First().Product.LeveranciersProductId);
            Assert.AreEqual(new DateTime(2010, 4, 6), result.BestellingCollection.First().BestellingsregelCollection.First().Product.LeverbaarVanaf);
        }
    }
}
