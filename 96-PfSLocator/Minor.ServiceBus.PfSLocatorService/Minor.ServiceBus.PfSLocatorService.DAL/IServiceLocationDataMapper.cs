using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace Minor.ServiceBus.PfSLocatorService
{
    [CLSCompliant(true)]
    public interface IServiceLocationDatamapper
    {
        string FindMetadataEndpointAddress(string name, string profile);
        string FindMetadataEndpointAddress(string name, string profile, decimal? version);
    }
}
