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

        public AgentPcSWinkelen()
        {
            _factory = new ServiceFactory<IWinkelenService>("PcSWinkelen");
        }

        public AgentPcSWinkelen(ServiceFactory<IWinkelenService> factory)
        {
            _factory = factory;
        }

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
