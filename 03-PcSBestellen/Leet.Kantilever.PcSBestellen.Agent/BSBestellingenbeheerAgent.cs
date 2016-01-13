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
    public class BSBestellingenbeheerAgent : IBSBestellingenbeheerAgent
    {
        private ServiceFactory<IBestellingenbeheerService> _factory;

        public BSBestellingenbeheerAgent()
        {
            _factory = new ServiceFactory<IBestellingenbeheerService>("BSBestellingenbeheer");
        }

        public BSBestellingenbeheerAgent(ServiceFactory<IBestellingenbeheerService> factory)
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

        public void CreateBestelling(Bestelling bestelling)
        {
            var agent = _factory.CreateAgent();
            
        }
    }
}
