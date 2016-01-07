using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEWebwinkel.Site.Controllers;
using Leet.Kantilever.FEWebwinkel.Site.Tests;
using System.Web.Mvc;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests.Controllers
{
    [TestClass]
    public class WinkelmandControllerTest
    {
        [TestMethod]
        public void ToonLegeWinkelmand()
        {
            //arrange 
            WinkelmandController controller = new WinkelmandController();
            controller.ControllerContext = Helper.CreateContext(controller);

            //act           
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName.ToString(), "LegeWinkelmand");
        }

        [TestMethod]
        public void ToonGevuldeWinkelmand()
        {
            //arrange 
            WinkelmandController controller = new WinkelmandController();
            controller.ControllerContext = Helper.CreateContext(controller);

            //act           
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName.ToString(), "Index");
        }
    }
}
