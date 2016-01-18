using Minor.case3.Leet.V1.FunctionalError;
using Minor.ServiceBus.Agent.Implementation;
using minorcase3pcswinkelen.v1.messages;
using minorcase3pcswinkelen.v1.schema;
using System.ServiceModel;

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

        /// <summary>
        /// Adds a product to a customers Winkelmand so he can order it at a later point in time.
        /// </summary>
        /// <param name="productID">The ID of the product to add</param>
        /// <param name="aantal">The number of the same product to add.</param>
        /// <param name="clientID">The ID of the client adding the product.</param>
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
        /// Returns the Winkelmand of a client.
        /// </summary>
        /// <param name="clientID">The ID of the client to return the Winkelmand of.</param>
        /// <returns></returns>
        public Winkelmand GetWinkelmand(string clientID)
        {
            var proxy = _factory.CreateAgent();

            try
            {
                var reqMessage = proxy.GetWinkelmandje(new VraagWinkelmandRequestMessage
                {
                    ClientID = clientID,
                });

                return reqMessage.Winkelmand;
            }
            catch (FaultException)
            {
                return new Winkelmand();
            }
        }

    }
}
