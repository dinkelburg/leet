using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEBestellingen.Site.Controllers;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using Moq;
using System.Collections.Generic;

namespace Leet.Kantilever.FEBestellingen.Site.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViewOrderReturnsViewResult()
        {
            // Arrange
            var mock = new Mock<IOrderManager>(MockBehavior.Strict);
            mock.Setup(om => om.GetOrderRegelsForOrder(1)).Returns(
                new List<OrderRegelVM> {
            #region mock data
                    new OrderRegelVM
                    {
                        Naam = "HL Road Frame - Black, 58",
                        Aantal = 5,
                        Leverancier = "Kaga Miyata",
                        Leverancierscode = 8
                    },
                    new OrderRegelVM
                    {
                        Naam = "HL Road Frame - Red, 58",
                        Aantal = 1,
                        Leverancier = "Eddy Merckx",
                        Leverancierscode = 9
                    },
                    new OrderRegelVM
                    {
                        Naam = "Sport-100 Helmet, Red",
                        Aantal = 3,
                        Leverancier = "Batavus",
                        Leverancierscode = 2
                    },
                    new OrderRegelVM
                    {
                        Naam = "Mountain Bike Socks, M",
                        Aantal = 9,
                        Leverancier = "Bikkel",
                        Leverancierscode = 6
                    },
            #endregion
                });
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.ViewOrder(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(IEnumerable<OrderRegelVM>));
        }

        [TestMethod]
        public void ViewOrderContains()
        {

        }
    }
}
