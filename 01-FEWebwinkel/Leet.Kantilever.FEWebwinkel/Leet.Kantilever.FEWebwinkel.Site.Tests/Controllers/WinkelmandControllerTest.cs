using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEWebwinkel.Site.Controllers;
using Leet.Kantilever.FEWebwinkel.Site.Tests;
using System.Web.Mvc;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using Moq;
using minorcase3pcswinkelen.v1.messages;

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
            //mock van de PcSWinkelen agent maken 
            //mock een neplijst laten returnen
            //context een guid string cookie geven

            //act           
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName.ToString(), "Index");
            // check result.model list length
        }

        [TestMethod]
        public void ProductAanWinkelmandToevoegen()
        {
            //arrange 
            var mock = new Mock<IWinkelenService>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IWinkelenService);
            controller.ControllerContext = Helper.CreateContext(controller);
            mock.Setup(m => m.VoegProductToe(It.IsAny<ToevoegenWinkelmandRequestMessage>()));

            //act
            var result = controller.VoegProductToe(123, 1);

            //assert
        }
    }
}
