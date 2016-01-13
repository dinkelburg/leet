using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minorcase3pcsbestellen.v1.schema;
using Minor.ServiceBus.Agent.Implementation;

namespace Leet.Kantilever.FEBestellingen.Agent
{
    public class AgentPcSBestellen : IAgentPcSBestellen
    {
        private ServiceFactory<IBestellenService> _factory;

        public AgentPcSBestellen()
        {
            _factory = new ServiceFactory<IBestellenService>("PcSBestellen");
        }

        public AgentPcSBestellen(ServiceFactory<IBestellenService> factory)
        {
            _factory = factory;
        }

        public BestellingCollection FindAllBestellingen()
        {

            var proxy = _factory.CreateAgent();
            var getBestellingenResponseMessage = proxy.FindAllBestellingen();
            return getBestellingenResponseMessage.BestellingCollection;
        }

        public Bestelling FindVolgendeOpenBestelling()
        {
            var proxy = _factory.CreateAgent();
            var bestelling = proxy.FindVolgendeOpenBestelling();
            return bestelling.Bestelling;
        }
    }
}

