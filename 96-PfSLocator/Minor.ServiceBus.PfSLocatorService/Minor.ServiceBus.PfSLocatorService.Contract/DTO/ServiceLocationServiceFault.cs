using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService
{
    [DataContract(Namespace = "urn:minor:servicebus:pfslocatorservice:servicefault")]
    public class ServiceLocationServiceFault
    {
        public ServiceLocationServiceFault() { }
        public ServiceLocationServiceFault(string message)
        {
            ErrorMessage = message;
        }

        public ServiceLocationServiceFault(string message, string details)
        {
            ErrorMessage = message;
            ErrorDetails = details;
        }

        public ServiceLocationServiceFault(bool result, string message, string details)
        {
            Result = result;
            ErrorMessage = message;
            ErrorDetails = details;
        }

        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ErrorDetails { get; set; }
    }
}
