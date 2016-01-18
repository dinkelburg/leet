using Leet.Kantilever.BSKlantbeheer.V1;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public class AgentBSKlantbeheer : IAgentBSKlantbeheer
    {
        private ServiceFactory<IKlantbeheerService> _factory;

        public AgentBSKlantbeheer()
        {
            _factory = new ServiceFactory<IKlantbeheerService>("BSKlantbeheer");
        }

        public AgentBSKlantbeheer(ServiceFactory<IKlantbeheerService> factory)
        {
            _factory = factory;
        }
    }
}
