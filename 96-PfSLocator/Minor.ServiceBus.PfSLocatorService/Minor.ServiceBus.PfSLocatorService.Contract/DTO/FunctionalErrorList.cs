using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService
{
    [DataContract(Namespace = "urn:minor:servicebus:pfslocatorservice:functionalerror")]
    public class FunctionalErrorList
    {
        private List<FunctionalErrorDetail> _details = new List<FunctionalErrorDetail>();

        public void Add(FunctionalErrorDetail detail)
        {
            _details.Add(detail);
        }

        public bool HasErrors => _details.Count > 0;

        [DataMember]
        public Collection<FunctionalErrorDetail> Details
        {
            get { return new Collection<FunctionalErrorDetail>(_details); }
        }
    }
}
