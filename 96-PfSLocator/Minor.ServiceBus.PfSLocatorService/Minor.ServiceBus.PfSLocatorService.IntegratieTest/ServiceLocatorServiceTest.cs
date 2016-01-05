using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Moq;
using Minor.ServiceBus.PfSLocatorService.Implementation;
using System.ServiceModel.Channels;

namespace Minor.ServiceBus.PfSLocatorService.IntegratieTest
{
    [TestClass]
    public class ServiceLocatorServiceTest
    {

        static private ServiceHost _host;
        private ChannelFactory<IServiceLocatorService> _factory;

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            _host = new ServiceHost(typeof(ServiceLocatorService));

            var contract = typeof(IServiceLocatorService);
            var binding = new NetNamedPipeBinding();
            var address = "net.pipe://localhost/ServiceLocatorService";
            _host.AddServiceEndpoint(contract, binding, address);
            _host.Open();
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            _host.Close();
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            EndpointAddress address = new EndpointAddress("net.pipe://localhost/ServiceLocatorService");
            Binding binding = new NetNamedPipeBinding();

            _factory = new ChannelFactory<IServiceLocatorService>(binding, address);
        }

        [TestMethod]
        public void Integration_FindMetaEA_WithVersion()
        {
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = "BSCurusadministatie",
                Profile = "Production"
            };
            
            IServiceLocatorService proxy = _factory.CreateChannel();

            string uri = proxy.FindMetadataEndpointAddress(serviceLocation);

            Assert.AreEqual("http://infosupport.intranet/CAS/mex", uri);
        }

        [TestMethod]
        public void Integration_FindMetaEA_WithoutVersion_Integration()
        {
            ServiceLocation serviceLocation = new ServiceLocation
            {
                Name = "PcSPlanningmaken",
                Profile = "Acceptation",
                Version = 1.0M
            };

            IServiceLocatorService proxy = _factory.CreateChannel();

            string uri = proxy.FindMetadataEndpointAddress(serviceLocation);

            Assert.AreEqual("http://infosupport.test/CAS/metadata", uri);
        }
    }
}
