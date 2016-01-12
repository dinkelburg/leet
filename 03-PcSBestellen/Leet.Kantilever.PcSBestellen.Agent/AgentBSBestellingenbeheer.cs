using Leet.Kantilever.BSBestellingenbeheer.V1;
using Leet.Kantilever.BSBestellingenbeheer.V1.Messages;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public class AgentBSBestellingenbeheer : IAgentBSBestellingenbeheer
    {
        private ServiceFactory<IBestellingenbeheerService> _factory;

        public AgentBSBestellingenbeheer()
        {
            _factory = new ServiceFactory<IBestellingenbeheerService>("BSBestellingenbeheer");
        }

        public AgentBSBestellingenbeheer(ServiceFactory<IBestellingenbeheerService> factory)
        {
            _factory = factory;
        }

        public Bestelling GetBestellingByID(long id)
        {
            var agent = _factory.CreateAgent();
            var msg = new GetBestellingByIDRequestMessage() { BestellingsID = id };
            return agent.FindBestelling(msg).Bestelling;
        }

        public IEnumerable<Bestelling> GetAllBestellingen()
        {
            var agent = _factory.CreateAgent();
            return agent.FindAllBestelling().BestellingCollection;
        }
    }
}
