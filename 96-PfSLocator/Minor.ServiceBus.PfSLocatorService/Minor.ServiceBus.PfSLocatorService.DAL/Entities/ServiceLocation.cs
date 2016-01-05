using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService.DAL.Entities
{
    public class ServiceLocation
    {
        public string Name { get; set; }
        public string Profile { get; set; }
        public decimal? Version { get; set; }
        public string Uri { get; set; }
    }
}
