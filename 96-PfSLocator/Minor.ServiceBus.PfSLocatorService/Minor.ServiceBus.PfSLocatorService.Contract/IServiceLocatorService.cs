using System.ServiceModel;

namespace Minor.ServiceBus.PfSLocatorService
{
    [ServiceContract(Namespace = "urn:minor:servicebus:pfslocatorservice")]
    public interface IServiceLocatorService
    {
        [OperationContract]
        [FaultContract(typeof(FunctionalErrorList))]
        string FindMetadataEndpointAddress(ServiceLocation serviceLocation);
    }
}
