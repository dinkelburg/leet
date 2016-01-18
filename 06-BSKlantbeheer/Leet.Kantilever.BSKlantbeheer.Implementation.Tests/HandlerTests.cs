using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.BSKlantbeheer.Contract;
using System.Collections.Generic;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using System.Data.Entity;
using Leet.Kantilever.BSKlantbeheer.DAL;
using System.Transactions;
using Leet.Kantilever.BSKlantbeheer.V1.Messages;
using System.ServiceModel;

namespace Leet.Kantilever.BSKlantbeheer.Implementation.Tests
{
    [TestClass]
    public class HandlerTests
    {
        private readonly Klant klant = new Klant { Voornaam = "Piet", Achternaam = "Willemsen", Email = "pietwillemsen@example.com", Gebruikersnaam = "pietje", Adresregel1 = "Eikenlaan 6", Adresregel2 = "B", Klantnummer = "4234fa", Postcode = "7324KK", ID = 6, Telefoonnummer = "+4465234624", Woonplaats = "Amsterdam" };

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Database.SetInitializer(new KlantDBInitializer());

            using (var context = new KlantenContext())
            {
                context.Database.Initialize(true);
            }

        }

        /// <summary>
        /// Moeten twee klanten zijn omdat de DB met 2 klanten geinitialiseerd wordt
        /// </summary>
        [TestMethod]
        public void GetAllKlanten_MockGeeftTweeKlantenTest()
        {
            // Arrange
            IKlantbeheerService service = new KlantbeheerServiceHandler();

            // Act
            var resultMsg = service.GetAllKlanten();
            ICollection<Klant> result = resultMsg.Klanten;

            // Assert
            Assert.AreEqual(2, result.Count);
        }


        [TestMethod]
        public void RegistreerKlant_MaaktVerzamelingEenGroterTest()
        {
            using (var trans = new TransactionScope())
            {
                // Arrange
                IKlantbeheerService service = new KlantbeheerServiceHandler();
                InsertKlantGegevensRequestMessage msg = new V1.Messages.InsertKlantGegevensRequestMessage { Klant = klant };

                // Act
                service.RegistreerKlant(msg);
                int count = service.GetAllKlanten().Klanten.Count;

                // Assert
                Assert.AreEqual(3, count);
            }
        }


        [TestMethod]
        public void RegistreerKlant_VoegKlantMetBestaandeGebruikersnaamToeTest()
        {
            using (var trans = new TransactionScope())
            {
                // Arrange
                // "jandevries123" bestaat al
                var klant = new Klant { Gebruikersnaam = "jandevries123", Voornaam = "Piet", Achternaam = "Jansen", Email = "bla@bla.nl", Adresregel1 = "1", Adresregel2 = "2", Klantnummer = "123", Postcode = "1234AS", Telefoonnummer = "2134", Woonplaats = "Urk", ID = 12435 };
                IKlantbeheerService service = new KlantbeheerServiceHandler();
                var msg = new InsertKlantGegevensRequestMessage() { Klant = klant };
                // Act
                try
                {
                    service.RegistreerKlant(msg);
                    // Assert
                    Assert.Fail();
                }
                catch (FaultException)
                {
                    // Moet hier langs gaan
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }
        }

        [TestMethod]
        public void GetKlant_HaalBestaandeKlantOpTest()
        {
            // Arrange
            IKlantbeheerService service = new KlantbeheerServiceHandler();
            string klantnummer = "ABCDEFG"; // Klantnummer van John Doe
            var msg = new V1.Messages.GetKlantByKlantnummerRequestMessage { Klantnummer = klantnummer };
            // Act
            Klant klant = service.GetKlant(msg).Klant;
            // Assert
            Assert.AreEqual("John", klant.Voornaam);
            Assert.IsNull(klant.Tussenvoegsel);
            Assert.AreEqual("Doe", klant.Achternaam);
        }


        [TestMethod, ExpectedException(typeof(FaultException))]
        public void RegistreerKlant_VoegIncompleteKlantToe()
        {
            // Arrange
            IKlantbeheerService service = new KlantbeheerServiceHandler();
            var klant = new Klant { Voornaam = "Bert", Achternaam = "van Dijk", Woonplaats = "Rotterdam" };
            var msg = new InsertKlantGegevensRequestMessage { Klant = klant };

            // Act
            service.RegistreerKlant(msg);

            // Assert
            // Assert gebeurt boven.
        }
    }
}
