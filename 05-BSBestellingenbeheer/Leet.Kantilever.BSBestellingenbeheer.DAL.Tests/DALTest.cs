using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using Leet.Kantilever.BSBestellingenbeheer.DAL.mappers;
using System;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    [TestClass]
    public class DALTest
    {
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Database.SetInitializer(new BestellingDBInitializer());

            using (var context = new BestellingContext())
            {
                context.Database.Initialize(false);
            }

        }

        [TestMethod]
        public void TestGetBestellingen()
        {

            // Arrange
            IBestellingMapper<Bestelling> bestellingMapper = new BestellingDataMapper();

            // Act
            var bestellingen = bestellingMapper.FindAll();

            // Assert
            Assert.AreEqual(4, bestellingen.Count());
        }


        [TestMethod]
        public void TestFindBestellingByID()
        {
            // Arrange
            IBestellingMapper<Bestelling> mapper = new BestellingDataMapper();

            // Act
            var bestelling = mapper.FindBestellingByID(2);


            // Assert
            var bestellingsregel = bestelling.Bestellingsregels.Where(regel => regel.ID == 2).First();
            Assert.AreEqual(2, bestelling.ID);
            Assert.IsTrue(bestelling.Ingepakt);
            Assert.AreEqual("Client01", bestelling.Klantnummer);
            Assert.AreEqual(2, bestellingsregel.ID);
            Assert.AreEqual(3, bestellingsregel.Aantal);
            Assert.AreEqual(5, bestellingsregel.ProductID);
            Assert.AreEqual(5.5M, bestellingsregel.Prijs);
        }


        [TestMethod]
        public void TestFindVolgendeOpenBestelling()
        {
            // Arrange
            IBestellingMapper<Bestelling> bestellingMapper = new BestellingDataMapper();

            // Act
            var openBestelling = bestellingMapper.FindVolgendeOpenBestelling();

            // Assert
            Assert.AreEqual(3, openBestelling.ID);

        }


        [TestMethod]
        public void AddNieuweBestellingReturntGrotereLijstTest()
        {
            // Arrange
            IBestellingMapper<Bestelling> bestellingMapper = new BestellingDataMapper();

            // Act
            var oudeBestellinglijst = bestellingMapper.FindAll();

            bestellingMapper.AddBestelling(DummyDataDAL.GetBestelling());

            var nieuweBestellinglijst = bestellingMapper.FindAll();

            // Assert
            Assert.AreEqual(4, oudeBestellinglijst.Count());
            Assert.AreEqual(5, nieuweBestellinglijst.Count());

        }


        [TestMethod]
        public void BestellingToDTO_CorrectGemapteDTO_Test()
        {
            // Arrange
            var bestelling = DummyDataDAL.GetBestelling();

            // Act
            var mappedBestelling = EntityToDTO.BestellingToDto(bestelling);

            // Assert
            Assert.AreEqual(bestelling.Bestelnummer, mappedBestelling.Bestelnummer);
            Assert.AreEqual(bestelling.Besteldatum, mappedBestelling.Besteldatum);
            for (int i = 0; i < bestelling.Bestellingsregels.Count(); i++)
            {
                Assert.AreEqual(bestelling.Bestellingsregels.ElementAt(i).Aantal, mappedBestelling.Bestellingsregels.ElementAt(i).Aantal);
                Assert.AreEqual(bestelling.Bestellingsregels.ElementAt(i).Prijs, mappedBestelling.Bestellingsregels.ElementAt(i).Prijs);
                Assert.AreEqual(bestelling.Bestellingsregels.ElementAt(i).ProductID, mappedBestelling.Bestellingsregels.ElementAt(i).ProductID);
            }
            Assert.AreEqual(bestelling.Ingepakt, mappedBestelling.Ingepakt);
            Assert.AreEqual(bestelling.Klantnummer, mappedBestelling.Klantnummer);
        }


        [TestMethod]
        public void BestellingToDTO_ArgumentNullExceptionWordtGegooid()
        {
            // Arrange

            // Act
            try
            {
                var mappedBestelling = EntityToDTO.BestellingToDto(null);
            }
            catch(ArgumentNullException e)
            {
                Assert.AreEqual("bestelling", e.ParamName);
            }
            catch(Exception e)
            {
                Assert.Fail();
            }

            // Assert
        }


        [TestMethod]
        public void BestellingToDTO_BestellingToDTOMapExceptionWordtGegooid()
        {
            // Arrange

            // Act

            // Assert

        }


        [TestMethod]
        public void BestellingsregelToDTOMapCorrectData()
        {
            // Arrange
            var bestellingsregels = DummyDataDAL.GetBestellingsRegels();

            // Act
            var mappedBestellingsRegels = EntityToDTO.BestellingsregelsToCollection(bestellingsregels);

            // Assert
            for(int i = 0; i < mappedBestellingsRegels.Count(); i++)
            {
                Assert.AreEqual(bestellingsregels[i].ProductID, mappedBestellingsRegels[i].ProductID);
                Assert.AreEqual(bestellingsregels[i].Aantal, mappedBestellingsRegels[i].Aantal);
                Assert.AreEqual(bestellingsregels[i].Prijs, mappedBestellingsRegels[i].Prijs);

            }
        }


        [TestMethod]
        public void BestellingsToDTO_ArgumentNullExceptionWordtGegooid()
        {
            // Arrange

            // Act
            try
            {
                var mappedBestellingsRegels = EntityToDTO.BestellingsregelToDto(null);
            }

            catch (Exception e) { };

            // Assert

        }


    }
}
