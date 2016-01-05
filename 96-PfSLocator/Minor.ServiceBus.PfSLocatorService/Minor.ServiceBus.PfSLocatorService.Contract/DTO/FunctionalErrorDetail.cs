using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService
{
    [DataContract(Namespace = "urn:minor:servicebus:pfslocatorservice:functionalerror")]
    public class FunctionalErrorDetail
    {
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public object Data { get; set; }
    }
}
