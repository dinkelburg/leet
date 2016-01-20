using System;
using Leet.Kantilever.BSBestellingenbeheer.DAL.converters;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    [TestClass]
    public class DTOToEntityTest
    {
        [TestMethod]
        public void BestellingToEntityWordtCorrectGemapped_Test()
        {
            //Arrange
            var bestelling = DummyDataDAL.GetDummyDataDTOBestelling();

            //Act
            var mappedBestelling = DTOToEntity.BestellingToEntity(bestelling);

            //Assert
            Assert.AreEqual(bestelling.Klantnummer, mappedBestelling.Klantnummer);
            Assert.AreEqual(bestelling.Besteldatum, mappedBestelling.Besteldatum);
            Assert.AreEqual(bestelling.Bestelnummer, mappedBestelling.Bestelnummer);
            Assert.AreEqual(bestelling.ID, mappedBestelling.ID);
            Assert.AreEqual((int)bestelling.Status, (int)mappedBestelling.Status);

            AssertBestellingsregels(bestelling, mappedBestelling);
        }

        private static void AssertBestellingsregels(Bestelling bestelling, Entities.Bestelling mappedBestelling)
        {
            for (int i = 0; i < bestelling.Bestellingsregels.Count(); i++)
            {
                var bestellingsregel = bestelling.Bestellingsregels[i];
                var mappedBestellingsregel = mappedBestelling.Bestellingsregels.ElementAt(i);
                Assert.AreEqual(bestellingsregel.ProductID, mappedBestellingsregel.ProductID);
                Assert.AreEqual(bestellingsregel.Aantal, mappedBestellingsregel.Aantal);
                Assert.AreEqual(bestellingsregel.Prijs, mappedBestellingsregel.Prijs);
            }
        }

        [TestMethod]
        public void BestellingToEntity_ArgumentNullExceptionWordtBijLegeBestellingGegooid_Test()
        {
            //Arrange

            //Act
            try
            {

                var mappedBestelling = DTOToEntity.BestellingToEntity(null);

            }
            //Assert
            catch (ArgumentNullException e)
            {

                Assert.AreEqual("bestelling", e.ParamName);
            }
        }

        [TestMethod]
        public void BestellingsregelsToEntity_CorrectDataWordtGemapped_Test()
        {
            //Arrange
            var bestellingsregel = DummyDataDAL.GetDummyDTOBestellinsregels()[0];

            //Act
            var mappedBestellingsregel = DTOToEntity.BestellingsregelToEntity(bestellingsregel);

            //Assert
            Assert.AreEqual(bestellingsregel.ProductID, mappedBestellingsregel.ProductID);
            Assert.AreEqual(bestellingsregel.Aantal, mappedBestellingsregel.Aantal);
            Assert.AreEqual(bestellingsregel.Prijs, mappedBestellingsregel.Prijs);
        }

        [TestMethod]
        public void BestellingToEntity_ArgumentNullExceptionWordtGegooidBijLegeBestellingsregel_Test()
        {
            //Arrange

            //Act
            try
            {
                var mappedBestellingsregel = DTOToEntity.BestellingsregelToEntity(null);
            }
            //Assert
            catch (ArgumentNullException e)
            {

                Assert.AreEqual("bestellingsregel", e.ParamName);
            }
        }
    }
}
