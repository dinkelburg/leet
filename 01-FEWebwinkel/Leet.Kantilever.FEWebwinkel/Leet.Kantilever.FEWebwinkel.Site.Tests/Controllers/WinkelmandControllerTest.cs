using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEWebwinkel.Site.Controllers;
using Leet.Kantilever.FEWebwinkel.Site.Tests;
using System.Web.Mvc;
using Leet.Kantilever.FEWebwinkel.Site.ViewModels;
using Moq;
using minorcase3pcswinkelen.v1.messages;
using minorcase3pcswinkelen.v1.schema;
using schemaswwwkantilevernl.bscatalogusbeheer.product.v1;

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
        public void ToonWinkelmandZonderClientId()
        {
            //arrange 
            var mock = new Mock<IWinkelenService>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IWinkelenService);
            controller.ControllerContext = Helper.CreateContext(controller);

            var winkelmandResponseMessage =
            #region winkelmand Mock ResponseMessage
            new WinkelmandResponseMessage
            {
                Winkelmand = new Winkelmand
                    {
                         new WinkelmandRegel
                         {
                             Aantal = 1,
                             Product = new Product()
                             {
                                 Naam = "Cool product",
                                 Prijs = ((decimal?) 123.12)
                             }
                         },
                         new WinkelmandRegel
                         {
                             Aantal = 1,
                             Product = new Product()
                             {
                                 Naam = "Cooler product",
                                 Prijs = ((decimal?) 456.5)
                             }
                         },
                         new WinkelmandRegel
                         {
                             Aantal = 1,
                             Product = new Product()
                             {
                                 Naam = "Coolste product",
                                 Prijs = 9001
                             }
                         },
                    }
            };
            #endregion

            mock.Setup(m => m.GetWinkelmandje(It.IsAny<VraagWinkelmandRequestMessage>())).Returns(winkelmandResponseMessage);
            //context een guid string cookie geven

            //act           
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName.ToString(), "LegeWinkelmand");
            // check result.model list length
        }

        [TestMethod]
        public void ProductAanWinkelmandToevoegenZonderClientId()
        {
            //arrange          
            var mock = new Mock<IWinkelenService>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IWinkelenService);

            //A controllercontext doesn't have any cookies in it by default so no further action is needed.
            controller.ControllerContext = Helper.CreateContext(controller);
            mock.Setup(m => m.VoegProductToe(It.IsAny<ToevoegenWinkelmandRequestMessage>()));

            //act
            var result = controller.VoegProductToe(123, 1) as HttpStatusCodeResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
            Assert.IsNotNull(controller.Response.Cookies.Get("clientId"));
        }
    }
}
