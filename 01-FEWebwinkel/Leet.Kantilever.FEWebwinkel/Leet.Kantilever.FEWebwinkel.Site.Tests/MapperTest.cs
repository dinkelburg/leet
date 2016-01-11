using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEWebwinkel.Agent.Tests;
using Kantilever.BsCatalogusbeheer.Product.V1;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests
{
    [TestClass]
    public class MapperTest
    {
        //[TestMethod]
        //public void MapToProductVMListTest()
        //{
        //    // Arrange
        //    var productCollection = DummyData.GetProductCollection();

        //    // Act
        //    var ProductVMList = Mapper.MapToProductVMList(productCollection);

        //    // Assert
        //    AssertProductCollectionWithProductVMList(productCollection, ProductVMList);
        //}

        private static void AssertProductCollectionWithProductVMList(ProductCollection productCollection, IEnumerable<ProductVM> productVMList)
        {
            var productVMArray = productVMList.ToArray();
            for (int i = 0; i < productCollection.Count; i++)
            {
                Assert.AreEqual(productVMArray[i].Id, productCollection[i].Id);
                Assert.AreEqual(productVMArray[i].Naam, productCollection[i].Naam);
                Assert.AreEqual(productVMArray[i].LeverancierNaam, productCollection[i].LeverancierNaam);
                Assert.AreEqual(productVMArray[i].AfbeeldingPad, Utility.AfbeeldingPrefix + productCollection[i].AfbeeldingURL);
                Assert.AreEqual(productVMArray[i].Prijs, productCollection[i].Prijs);
            }
        }
    }
}
