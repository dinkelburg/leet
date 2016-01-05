using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minor.ServiceBus.PfSLocatorService.DAL.Test
{
    [TestClass]
    public class ServiceLocationXMLDataMapperTest
    {
        [TestMethod]
        public void FileServiceLocator_Bestaat()
        {
            //Arrange
            var serviceLocator = new ServiceLocationXmlDatamapper(@"..\..\..\locationData.xml");

            //Assert
            Assert.IsInstanceOfType(serviceLocator, typeof(ServiceLocationXmlDatamapper));
        }

        [TestMethod]
        public void GetMexAdressMetNaamEnProfiel()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            //Act
            var adress = fileServiceLocator.FindMetadataEndpointAddress("BSKlantbeheer", "Development");

            //Assert
            Assert.AreEqual("http://localhost:30412/BSKlantbeheer/mex", adress);
        }

        [TestMethod]
        public void GetMexAdressMetNaamEnProfielEnVersion()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            //Act
            var adress = fileServiceLocator.FindMetadataEndpointAddress("PcSPlanningmaken", "Acceptation", 1.0m);

            //Assert
            Assert.AreEqual("http://infosupport.test/CAS", adress);
        }

        [TestMethod]
        [ExpectedException(typeof(FilePathNotDefinedException))]
        public void PathfileIsEmptyString_En_Verwacht_FilePathNotDefinedException()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper("");

            //Act
            var adress = fileServiceLocator.FindMetadataEndpointAddress("BSCurusadministatie", "Production");

            //Assert
            Assert.AreEqual("http://infosupport.intranet/CAS/mex", adress);
        }

        [TestMethod]
        [ExpectedException(typeof(MultipleRecordsFoundException))]
        public void GetMexAdress_WithoutVersion_MultipleRecordsFound()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            //Act
            var adress = fileServiceLocator.FindMetadataEndpointAddress("BSCursusadministatie", "Production");

            //Assert
            //Exception thrown
        }

        [TestMethod]
        public void GetMexAdress_WithoutVersion_MultipleRecordsFound_ExcMessage()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            try
            {
                //Act
                var adress = fileServiceLocator.FindMetadataEndpointAddress("BSCursusadministatie", "Production");
            }
            catch (MultipleRecordsFoundException ex)
            {
                //Assert
                Assert.AreEqual("Multiple location services found instead of one", ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NoRecordsFoundException))]
        public void GetMexAdress_WithoutVersion_NoRecordsFound()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            //Act
            var adress = fileServiceLocator.FindMetadataEndpointAddress("BSCursusafsadfs", "Prodduction");

            //Assert
            //Exception thrown
        }

        [TestMethod]
        public void GetMexAdress_WithoutVersion_NoRecordsFound_ExcMessage()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            try
            {
                //Act
                var adress = fileServiceLocator.FindMetadataEndpointAddress("BSCursusafsadfs", "Prodduction");
            }
            catch (NoRecordsFoundException ex)
            {
                //Assert
                Assert.AreEqual("No location services found", ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(VersionedRecordFoundException))]
        public void GetMexAdress_WithoutVersion_VersionedRecordFound()
        {
            //Arrange
            var fileServiceLocator = new ServiceLocationXmlDatamapper(@"locationData.xml");

            //Act
            var adress = fileServiceLocator.FindMetadataEndpointAddress("PcSPlanningmaken", "Acceptation");

            //Assert
            //Exception thrown
        }
    }
}
