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
using Leet.Kantilever.FEWebwinkel.Agent;
using System.Collections.Generic;
using System.Web;
using Leet.Kantilever.FEWebwinkel.Agent.Tests;

namespace Leet.Kantilever.FEWebwinkel.Site.Tests.Controllers
{
    [TestClass]
    public class WinkelmandControllerTest
    {
        [TestMethod]
        public void ToonLegeWinkelmand()
        {
            //arrange 
            var mock = new Mock<IAgentPcSWinkelen>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IAgentPcSWinkelen);
            controller.ControllerContext = Helper.CreateContext(controller);
            mock.Setup(m => m.GetWinkelmand(It.IsAny<string>())).Returns(new Winkelmand());

            //act           
            var result = controller.Index() as ViewResult;

            //assert
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName.ToString(), "LegeWinkelmand");
            Assert.IsNull(result.ViewBag.CountProduct);
        }

        [TestMethod]
        public void ToonWinkelmandZonderClientId()
        {
            //arrange 
            var mock = new Mock<IAgentPcSWinkelen>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IAgentPcSWinkelen);
            controller.ControllerContext = Helper.CreateContext(controller);
            mock.Setup(m => m.GetWinkelmand(It.IsAny<string>())).Returns(new Winkelmand());

            //act           
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName.ToString(), "LegeWinkelmand");
            Assert.IsNull(result.ViewBag.CountProduct);
        }

        [TestMethod]
        public void ProductAanWinkelmandToevoegenZonderClientId()
        {
            //arrange          
            var mock = new Mock<IAgentPcSWinkelen>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IAgentPcSWinkelen);

            //A controllercontext doesn't have any cookies in it by default so no further action is needed.
            controller.ControllerContext = Helper.CreateContext(controller);
            mock.Setup(m => m.VoegProductToeAanWinkelmand(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(DummyData.GetWinkelmand());

            //act
            var result = controller.VoegProductToe(123, 1) as JsonResult;

            //assert
            mock.Verify(m => m.VoegProductToeAanWinkelmand(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsNotNull(controller.Response.Cookies.Get("clientId"));
        }

        [TestMethod]
        public void ToonGevuldeWinkelmand()
        {
            //arrange
            var mock = new Mock<IAgentPcSWinkelen>();
            WinkelmandController controller = new WinkelmandController(mock.Object as IAgentPcSWinkelen);
            controller.ControllerContext = Helper.CreateContext(controller);
            Helper.SetCookie("clientId", controller);

            Winkelmand winkelmand = new Winkelmand();

            winkelmand.AddRange(
            #region winkelmand Mock
            new List<WinkelmandRegel> {
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
            });
            #endregion

            mock.Setup(m => m.GetWinkelmand(It.IsAny<string>())).Returns(winkelmand);

            //act 
            var result = controller.Index() as ViewResult;
            var winkelmandCount = (result.Model as WinkelmandVM).Producten.Count;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, winkelmandCount);
        }

        [TestMethod]
        public void ClientIdZonderRequest()
        {
            //arrange
            var exceptionCaught = false;
            var context = new Mock<HttpContextBase>();
            var responseMock = new Mock<HttpResponseBase>();

            context.SetupGet(c => c.Response)
                   .Returns(responseMock.Object);

            string message = string.Empty;

            //act
            try
            {
                var result = Utility.CheckClientID(null, responseMock.Object);
            }
            catch (ArgumentNullException ex)
            {
                exceptionCaught = true;
                message = ex.Message;
            }

            //assert
            Assert.IsTrue(exceptionCaught);
            Assert.AreEqual("The request object was null.\r\nParameter name: request", message);
        }

        [TestMethod]
        public void ClientIdZonderResponse()
        {
            //arrange
            var exceptionCaught = false;
            string message = string.Empty;

            var context = new Mock<HttpContextBase>();
            var requestMock = new Mock<HttpRequestBase>();

            context.SetupGet(c => c.Request)
                   .Returns(requestMock.Object);

            //act
            try
            {
                var result = Utility.CheckClientID(requestMock.Object, null);
            }
            catch (ArgumentNullException ex)
            {
                exceptionCaught = true;
                message = ex.Message;
            }

            //assert
            Assert.IsTrue(exceptionCaught);
            Assert.AreEqual("The response object was null.\r\nParameter name: response", message);
        }
    }
}
