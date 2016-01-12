using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using minorcase3pcsbestellen.v1.schema;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Leet.Kantilever.FEBestellingen.Site.Tests
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void MapToBestellingVMListTest()
        {
            // Arrange
            var bestellingCollection = DummyData.GetBestellingCollection();

            // Act
            var bestellingVMList = Mapper.MapBestellingToVMList(bestellingCollection);

            // Assert
            AssertBestellingCollectionWithProductVMList(bestellingCollection, bestellingVMList);
        }

        private static void AssertBestellingCollectionWithProductVMList(BestellingCollection bestellingCollection, IEnumerable<BestellingVM> bestellingVMList)
        {
            var bestellingVMArray = bestellingVMList.ToArray();
            for (int i = 0; i < bestellingCollection.Count; i++)
            {
                Assert.AreEqual(bestellingVMArray[i].Besteldatum, bestellingCollection[i].Besteldatum);
                Assert.AreEqual(bestellingVMArray[i].Bestelnummer, bestellingCollection[i].Bestelnummer);
                for(int j = 0; j < bestellingVMArray[i].Bestellingsregels.Count; j++)
                {
                    Assert.AreEqual(bestellingCollection[i].BestellingsregelCollection[j].Product.Naam, bestellingVMArray[i].Bestellingsregels[j].ProductNaam);
                    Assert.AreEqual(bestellingCollection[i].BestellingsregelCollection[j].Product.LeveranciersProductId, bestellingVMArray[i].Bestellingsregels[j].Leverancierscode);
                    Assert.AreEqual(bestellingCollection[i].BestellingsregelCollection[j].Aantal, bestellingVMArray[i].Bestellingsregels[j].Aantal);

                }
            }
        }
    }
}
