using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcSBestellen = minorcase3pcsbestellen.v1.schema;
using Minor.ServiceBus.Agent.Implementation;
using minorcase3pcsbestellen.v1.messages;
using minorcase3bsklantbeheer.v1.schema;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;

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

        public PcSBestellen.BestellingCollection FindAllBestellingen()
        {
            var proxy = _factory.CreateAgent();
            var getBestellingenResponseMessage = proxy.FindAllBestellingen();
            return getBestellingenResponseMessage.BestellingCollection;
        }

        public IEnumerable<PcSBestellen.Bestelling> FindAllNewBestellingen()
        {
            var proxy = _factory.CreateAgent();
            var getBestellingenResponseMessage = proxy.FindAllBestellingen();
            return getBestellingenResponseMessage.BestellingCollection.Where(bestelling => (((Bestellingsstatus)bestelling.Status) & Bestellingsstatus.Nieuw) > 0 );
        }

        public PcSBestellen.Bestelling FindVolgendeOpenBestelling()
        {
            var proxy = _factory.CreateAgent();
            var bestelling = proxy.FindVolgendeOpenBestelling();
            return bestelling.Bestelling;
        }

        public PcSBestellen.Bestelling FindBestellingByBestelnummer(long bestelnummer)
        {
            var proxy = _factory.CreateAgent();
            var requestMessage = new GetBestellingByIDRequestMessage
            {
                BestellingsID = bestelnummer
            };
            var responseMessage = proxy.FindBestellingByBestelnummer(requestMessage);
            return responseMessage.Bestelling;
        }

        public void UpdateBestelling(PcSBestellen.Bestelling bestelling)
        {
            var proxy = _factory.CreateAgent();
            proxy.UpdateBestelling(new UpdateBestellingRequestMessage { Bestelling = bestelling });
        }

    }
}

