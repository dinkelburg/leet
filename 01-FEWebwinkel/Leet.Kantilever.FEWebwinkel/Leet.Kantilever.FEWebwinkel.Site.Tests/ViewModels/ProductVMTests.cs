using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests.ViewModels
{
    [TestClass]
    public class ProductVMTests
    {
        [TestMethod]
        public void ProductVM_PrijsInclusiefBtwGeeftGoedeWaarde()
        {
            //arrange
            ProductVM p = new ProductVM
            {
                Prijs = 10m
            };

            //act
            var result = p.PrijsInclusiefBtw;

            //assert
            Assert.AreEqual(12.10m, result);
        }

        [TestMethod]
        public void ProductVM_PrijsInclusiefWerktMetNullPrijs()
        {
            //arrange
            ProductVM p = new ProductVM();

            //act
            var result = p.PrijsInclusiefBtw;

            //assert
            Assert.AreEqual(null, result);
        }
    }
}
