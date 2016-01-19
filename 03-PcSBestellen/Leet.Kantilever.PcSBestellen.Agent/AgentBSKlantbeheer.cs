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

        /// <summary>
        /// Contstructor to instantiate AgentBSKlantbeheer with a ServiceFactory
        /// </summary>
        public AgentBSKlantbeheer()
        {
            _factory = new ServiceFactory<IKlantbeheerService>("BSklantbeheer");
        }


        /// <summary>
        /// Constructor to instantiate AgentBSKlantbeheer with a injectable ServiceFactory<IKlantbeheerService>
        /// </summary>
        /// <param name="factory">ServiceFactory<IKlantbeheerService> to inject</param>
        public AgentBSKlantbeheer(ServiceFactory<IKlantbeheerService> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Get klant from BSklantbeheer matching the klantnummer
        /// </summary>
        /// <param name="klantnummer">Klantnummer to find the klant</param>
        /// <returns>The klant corresponding to the klantnummer</returns>
        public Klant GetKlant(string klantnummer)
        {
            if(string.IsNullOrEmpty(klantnummer))
            {
                throw new ArgumentNullException("Klantnummer mag niet null zijn om een klant te zoeken");
            }

            var proxy = _factory.CreateAgent();
            var responseMessage =  proxy.GetKlant(new GetKlantByKlantnummerRequestMessage
            {
                Klantnummer = klantnummer,
            });

            return responseMessage.Klant;
        }

        /// <summary>
        /// Register klant in the BSklantbeheer
        /// </summary>
        /// <param name="klant">Klant to persist</param>
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
