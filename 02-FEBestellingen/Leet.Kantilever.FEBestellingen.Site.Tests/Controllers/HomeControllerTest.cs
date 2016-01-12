//using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Leet.Kantilever.FEBestellingen.Site.Controllers;
//using Leet.Kantilever.FEBestellingen.Site.ViewModels;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;

//namespace Leet.Kantilever.FEBestellingen.Site.Tests.Controllers
//{
//    [TestClass]
//    public class HomeControllerTest
//    {
//        private IEnumerable<BestellingsRegelVM> _mockdata =
//        #region Mock data
//            new List<BestellingsRegelVM> {
//                    new BestellingsRegelVM
//                    {
//                        ProductNaam = "HL Road Frame - Black, 58",
//                        Aantal = 5,
//                        Leverancier = "Kaga Miyata",
//                        Leverancierscode = 8
//                    },
//                    new BestellingsRegelVM
//                    {
//                        ProductNaam = "HL Road Frame - Red, 58",
//                        Aantal = 1,
//                        Leverancier = "Eddy Merckx",
//                        Leverancierscode = 9
//                    },
//                    new BestellingsRegelVM
//                    {
//                        ProductNaam = "Sport-100 Helmet, Red",
//                        Aantal = 3,
//                        Leverancier = "Batavus",
//                        Leverancierscode = 2
//                    },
//                    new BestellingsRegelVM
//                    {
//                        ProductNaam = "Mountain Bike Socks, M",
//                        Aantal = 9,
//                        Leverancier = "Bikkel",
//                        Leverancierscode = 6
//                    },
//        };
//        #endregion

//        [TestMethod]
//        public void ViewOrderReturnsViewResult()
//        {
//            // Arrange
//            var mock = new Mock<IOrderManager>(MockBehavior.Strict);
//            mock.Setup(om => om.GetOrderRegelsForOrder(1)).Returns(_mockdata);
//            var controller = new HomeController(mock.Object);

//            // Act
//            var result = controller.ViewOrder(1);

//            // Assert
//            Assert.IsInstanceOfType(result, typeof(ViewResult));
//            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(IEnumerable<BestellingsRegelVM>));
//        }

//        [TestMethod]
//        public void ViewOrderCallsOrderManager()
//        {
//            // Arrange
//            var mock = new Mock<IOrderManager>(MockBehavior.Strict);
//            mock.Setup(om => om.GetOrderRegelsForOrder(1)).Returns(_mockdata)
//                .Verifiable();
//            var controller = new HomeController(mock.Object);

//            // Act
//            var result = controller.ViewOrder(1);

//            // Assert
//            mock.Verify(om => om.GetOrderRegelsForOrder(1), Times.AtLeastOnce, "Method not called");
//            mock.Verify(om => om.GetOrderRegelsForOrder(1), Times.Once, "Method called more than once");
//        }


//        [TestMethod]
//        public void ViewOrderFillsModel()
//        {
//            // Arrange
//            var mock = new Mock<IOrderManager>(MockBehavior.Strict);
//            mock.Setup(om => om.GetOrderRegelsForOrder(1)).Returns(_mockdata)
//                .Verifiable();
//            var controller = new HomeController(mock.Object);

//            // Act
//            var result = controller.ViewOrder(1);

//            // Assert
//            IEnumerable<BestellingsRegelVM> model = ((ViewResult)result).Model as IEnumerable<BestellingsRegelVM>;
//            Assert.AreEqual(model.Count(), _mockdata.Count());
//            Assert.AreEqual(model.First(), _mockdata.First());
//        }
//    }
//}
