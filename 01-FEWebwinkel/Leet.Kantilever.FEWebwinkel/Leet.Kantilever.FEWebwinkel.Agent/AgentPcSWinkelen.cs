using Minor.ServiceBus.Agent.Implementation;
using minorcase3pcswinkelen.v1.messages;
using minorcase3pcswinkelen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEWebwinkel.Agent
{
    public class AgentPcSWinkelen : IAgentPcSWinkelen
    {
        private ServiceFactory<IWinkelenService> _factory;

        /// <summary>
        /// Constructor to instantiate AgentPcSWinkelen with a SerciceFactory
        /// </summary>
        public AgentPcSWinkelen()
        {
            _factory = new ServiceFactory<IWinkelenService>("PcSWinkelen");
        }

        /// <summary>
        /// Constructor to instantiate AgentPcSWinkelen and to inject a SerciceFactory mock
        /// </summary>
        /// <param name="factory">ServiceFactory mock</param>
        public AgentPcSWinkelen(ServiceFactory<IWinkelenService> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Add a product to a Winkelmand in the PcSCatalogus
        /// </summary>
        /// <param name="productID">ProductID of the product to add to the Winkelmand</param>
        /// <param name="aantal">Aantal of the product</param>
        /// <param name="clientID">ClientID of the Winkelmand</param>
        /// <returns></returns>
        public Winkelmand VoegProductToeAanWinkelmand(int productID, int aantal, string clientID)
        {
            var proxy = _factory.CreateAgent();

            var reqMessage = proxy.VoegProductToe(new ToevoegenWinkelmandRequestMessage
            {
                BestelProduct = new BestelProduct
                {
                    ProductID = productID,
                    Aantal = aantal,
                    ClientID = clientID,
                },
            });

            return reqMessage.Winkelmand;
        }

        /// <summary>
        /// Get the Winkelmand from the PcSWinkelen that matches a specific ClientID
        /// </summary>
        /// <param name="clientID">ClientID of the Winkelmand</param>
        /// <returns>Winkelmand that matches the ClientID</returns>
        public Winkelmand GetWinkelmand(string clientID)
        {
            var proxy = _factory.CreateAgent();

            var reqMessage = proxy.GetWinkelmandje(new VraagWinkelmandRequestMessage
            {
                ClientID = clientID,
            });

            return reqMessage.Winkelmand;
        }

    }
}
