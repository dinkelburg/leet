using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using Leet.Kantilever.BSBestellingenbeheer.DAL.mappers;
using System;
using System.Transactions;

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
        public void GetBestellingen_CorrecteBestellingenWordenGereturnd_Test()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                IDatamapper<Bestelling> bestellingMapper = new BestellingDataMapper();

                // Act
                var bestellingen = bestellingMapper.FindAll();

                // Assert
                Assert.AreEqual(5, bestellingen.Count());
            }
        }


        [TestMethod]
        public void FindBestellingByID_CorrecteBestellingWordtGereturnd()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                IDatamapper<Bestelling> mapper = new BestellingDataMapper();

                // Act
                var bestelling = mapper.FindByID(2);


                // Assert
                var bestellingsregel = bestelling.Bestellingsregels.Where(regel => regel.ID == 2).First();
                Assert.AreEqual(2, bestelling.ID);
                Assert.AreEqual(Bestelling.BestellingStatus.Ingepakt, bestelling.Status);
                Assert.AreEqual("Client01", bestelling.Klantnummer);
                Assert.AreEqual(2, bestellingsregel.ID);
                Assert.AreEqual(3, bestellingsregel.Aantal);
                Assert.AreEqual(5, bestellingsregel.ProductID);
                Assert.AreEqual(5.5M, bestellingsregel.Prijs);
            }
        }


        [TestMethod]
        public void FindVolgendeOpenBestelling_CorrecteVolgendeBestellingWordtGereturnd_Test()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                IDatamapper<Bestelling> bestellingMapper = new BestellingDataMapper();

                // Act
                var openBestelling = bestellingMapper.FindNext();

                // Assert
                Assert.AreEqual(4, openBestelling.ID);
            }

        }


        [TestMethod]
        public void Update_BestellingKrijgtStatusIngepakt_Test()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                var mapper = new BestellingDataMapper();
                var oudeBestelling = mapper.FindNext();


                // Act
                oudeBestelling.Status = Bestelling.BestellingStatus.Ingepakt;
                mapper.Update(oudeBestelling);


                var nieuweBestelling = mapper.Find(b => b.Bestelnummer == oudeBestelling.Bestelnummer).Single();

                // Assert
                Assert.AreEqual(Bestelling.BestellingStatus.Ingepakt, nieuweBestelling.Status);
            }
        }

        [TestMethod]
        public void AddNieuweBestelling_ArgumentNullExceptionWordtGegooid_Test()
        {
            using (var scope = new TransactionScope())
            {
                //Arrange
                IDatamapper<Bestelling> bestellingMapper = new BestellingDataMapper();

                //Act
                try
                {
                    bestellingMapper.Insert(null);
                }

                //Assert
                catch (ArgumentNullException e)
                {
                    Assert.AreEqual("bestelling", e.ParamName);
                }
            }
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
            Assert.AreEqual((int)bestelling.Status, (int)mappedBestelling.Status);
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
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("bestelling", e.ParamName);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            // Assert

        }

        [TestMethod]
        public void BestellingsregelToDTOMapCorrectData_Test()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                var bestellingsregels = DummyDataDAL.GetBestellingsRegels();

                // Act
                var mappedBestellingsregels = EntityToDTO.BestellingsregelsToCollection(bestellingsregels);

                // Assert
                for (int i = 0; i < mappedBestellingsregels.Count; i++)
                {
                    Assert.AreEqual(bestellingsregels[i].ProductID, mappedBestellingsregels[i].ProductID);
                    Assert.AreEqual(bestellingsregels[i].Aantal, mappedBestellingsregels[i].Aantal);
                    Assert.AreEqual(bestellingsregels[i].Prijs, mappedBestellingsregels[i].Prijs);
                }
            }
        }

        [TestMethod]
        public void BestellingsregelToCollection_ArgumentNullExceptionWordtGegooid_Test()
        {
            using (var scope = new TransactionScope())
            {
                //Arrange

                //Act
                try
                {
                    var mappedBestellingsregel = EntityToDTO.BestellingsregelsToCollection(null);
                }
                catch (ArgumentNullException e)
                {

                    Assert.AreEqual("regels", e.ParamName);
                }


                //Assert
            }
        }


        [TestMethod]
        public void BestellingsToDTO_ArgumentNullExceptionWordtGegooid_Test()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange

                // Act
                try
                {
                    var mappedBestellingsRegels = EntityToDTO.BestellingsregelToDto(null);
                }

                //Assert
                catch (ArgumentNullException e)
                {
                    Assert.AreEqual("regel", e.ParamName);
                }
            }
        }

        [TestMethod]
        public void BestellingsregelToDTO_CorrecteDataWordtGemapped_Test()
        {
            using (var scope = new TransactionScope())
            {
                //Arrange
                var bestellingsregel = DummyDataDAL.GetBestellingsRegels()[0];

                //Act
                var mappedBestellingsregel = EntityToDTO.BestellingsregelToDto(bestellingsregel);

                //Assert
                Assert.AreEqual(bestellingsregel.ProductID, mappedBestellingsregel.ProductID);
                Assert.AreEqual(bestellingsregel.Aantal, mappedBestellingsregel.Aantal);
                Assert.AreEqual(bestellingsregel.Prijs, mappedBestellingsregel.Prijs);
            }
        }

        [TestMethod]
        public void FindBestellingenByKlant_GeeftLijstMetBestellingen()
        {
            using (var scope = new TransactionScope())
            {
                //arrange
                var mapper = new BestellingDataMapper();

                //act
                var result = mapper.Find(b => b.Klantnummer == "Client02");

                //assert
                Assert.AreEqual(5, result.First().ID);
            }
        }

        [TestMethod]
        public void FindBestellingenByKlant_GeeftLegeLijstAlsErGeenBestellingenZijnGevonden()
        {
            using (var scope = new TransactionScope())
            {
                //arrange
                var mapper = new BestellingDataMapper();

                //act
                //cast to List to be able to use the Count property. 
                var result = mapper.Find(b => b.Klantnummer == "Client03") as List<Bestelling>;

                //assert
                Assert.AreEqual(0, result.Count);
            }
        }


        [TestMethod]
        public void BestellingCollectionToDto_GeeftLijstTerugBijCorrecteInput()
        {
            using (var scope = new TransactionScope())
            {
                //arrange
                var bestellingCollection = DummyDataDAL.GetDummyBestellingen();

                //act
                var result = EntityToDTO.BestellingCollectionToDto(bestellingCollection);

                //assert
                Assert.AreEqual(4, result.Count);
                Assert.AreEqual(2, result.First().ID);
            }
        }

        [TestMethod]
        public void BestellingCollectionToDto_GeeftLegeLijstTerugBijGeenBestellingen()
        {
            using (var scope = new TransactionScope())
            {
                //arrange
                var bestellingCollection = new List<Bestelling>();

                //act
                var result = EntityToDTO.BestellingCollectionToDto(bestellingCollection);

                //assert
                Assert.AreEqual(0, result.Count);
            }
        }
    }
}
