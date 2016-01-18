using Leet.Kantilever.BSKlantbeheer.V1;
using Leet.Kantilever.BSKlantbeheer.V1.Messages;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
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
            _factory = new ServiceFactory<IKlantbeheerService>("BSklantbeheer");
        }

        public AgentBSKlantbeheer(ServiceFactory<IKlantbeheerService> factory)
        {
            _factory = factory;
        }

        public Klant GetKlant(string klantnummer)
        {
            var proxy = _factory.CreateAgent();
            var responseMessage =  proxy.GetKlant(new GetKlantByKlantnummerRequestMessage
            {
                Klantnummer = klantnummer,
            });

            return responseMessage.Klant;
        }

        public void RegistreerKlant(Klant klant)
        {
            var proxy = _factory.CreateAgent();
            proxy.RegistreerKlant(new InsertKlantGegevensRequestMessage
            {
                Klant = klant,
            });
        }
    }
}
