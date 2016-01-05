using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService
{
    [DataContract(Namespace = "urn:minor:servicebus:pfslocatorservice:schema")]
    public class ServiceLocation
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Profile { get; set; }
        [DataMember]
        public decimal? Version { get; set; }
    }
}
