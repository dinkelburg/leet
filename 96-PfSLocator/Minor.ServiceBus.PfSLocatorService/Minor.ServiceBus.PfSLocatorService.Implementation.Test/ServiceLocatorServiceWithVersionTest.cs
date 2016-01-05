using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ServiceModel;

namespace Minor.ServiceBus.PfSLocatorService.Implementation.Test
{
    [TestClass]
    public class ServiceLocatorServiceWithVersionTest
    {
        [TestMethod]
        public void FindMetaEA_WithVersion_FoundSingle()
        {
            // Arrange
            string name = "BSKlantBeheer";
            string profile = "Development";
            decimal? version = 1.0m;
            string expected = "http://localhost:30412/BSKlantbeheer/mex";
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = name,
                Profile = profile,
                Version = version
            };

            var mock = new Mock<IServiceLocationDatamapper>(MockBehavior.Strict);
            mock.Setup(m => m.FindMetadataEndpointAddress(name, profile, version)).Returns(expected);
            var target = new ServiceLocatorService(mock.Object);

            // Act
            var result = target.FindMetadataEndpointAddress(serviceLocation);

            // Assert
            mock.Verify(m => m.FindMetadataEndpointAddress(name, profile, version), Times.Once);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<FunctionalErrorList>))]
        public void FindMetaEA_WithVersion_FoundMultiple()
        {
            // Arrange
            string name = "BSKlantBeheer";
            string profile = "Development";
            decimal? version = 1.0m;
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = name,
                Profile = profile,
                Version = version
            };

            var mock = new Mock<IServiceLocationDatamapper>(MockBehavior.Strict);
            mock.Setup(m => m.FindMetadataEndpointAddress(name, profile, version))
                .Throws(new MultipleRecordsFoundException("Multiple location services found instead of one"));
            var target = new ServiceLocatorService(mock.Object);

            // Act
            var result = target.FindMetadataEndpointAddress(serviceLocation);

            // Assert
            //Exception thrown
        }

        [TestMethod]
        public void FindMetaEA_WithVersion_FoundMultiple_ExcMessage()
        {
            // Arrange
            string name = "BSKlantBeheer";
            string profile = "Development";
            decimal? version = 1.0m;
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = name,
                Profile = profile,
                Version = version
            };

            var mock = new Mock<IServiceLocationDatamapper>(MockBehavior.Strict);
            mock.Setup(m => m.FindMetadataEndpointAddress(name, profile, version))
                .Throws(new MultipleRecordsFoundException("Multiple location services found instead of one"));
            var target = new ServiceLocatorService(mock.Object);

            try
            {
                // Act
                var result = target.FindMetadataEndpointAddress(serviceLocation);
                Assert.Fail();
            }
            catch (FaultException<FunctionalErrorList> ex)
            {
                // Assert
                Assert.AreEqual(1, ex.Detail.Details.Count);
                Assert.AreEqual("Multiple location services found instead of one", ex.Detail.Details[0].Message);
            }
            
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<FunctionalErrorList>))]
        public void FindMetaEA_WithVersion_FoundNone()
        {
            // Arrange
            string name = "BSKlantBeheer";
            string profile = "Development";
            decimal? version = 1.0m;
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = name,
                Profile = profile,
                Version = version
            };

            var mock = new Mock<IServiceLocationDatamapper>(MockBehavior.Strict);
            mock.Setup(m => m.FindMetadataEndpointAddress(name, profile, version))
                .Throws(new NoRecordsFoundException("No location services found"));
            var target = new ServiceLocatorService(mock.Object);

            // Act
            var result = target.FindMetadataEndpointAddress(serviceLocation);

            // Assert
            //Exception thrown
        }

        [TestMethod]
        public void FindMetaEA_WithVersion_FoundNone_ExcMessage()
        {
            // Arrange
            string name = "BSKlantBeheer";
            string profile = "Development";
            decimal? version = 1.0m;
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = name,
                Profile = profile,
                Version = version
            };

            var mock = new Mock<IServiceLocationDatamapper>(MockBehavior.Strict);
            mock.Setup(m => m.FindMetadataEndpointAddress(name, profile, version))
                .Throws(new NoRecordsFoundException("No location services found"));
            var target = new ServiceLocatorService(mock.Object);

            try
            {
                // Act
                var result = target.FindMetadataEndpointAddress(serviceLocation);
                Assert.Fail();
            }
            catch (FaultException<FunctionalErrorList> ex)
            {
                // Assert
                Assert.AreEqual(1, ex.Detail.Details.Count);
                Assert.AreEqual("No location services found", ex.Detail.Details[0].Message);
            }
        }
    }
}
