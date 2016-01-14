using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leet.Kantilever.PcSWinkelen.V1.Schema;
using Minor.ServiceBus.Agent.Implementation;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public class AgentPcSWinkelen : IAgentPcSWinkelen
    {
        private ServiceFactory<IWinkelenService> _factory;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AgentPcSWinkelen()
        {
            _factory = new ServiceFactory<IWinkelenService>("PcSWinkelen");
        }

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="factory"></param>
        public AgentPcSWinkelen(ServiceFactory<IWinkelenService> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Remove a winkelmand
        /// </summary>
        /// <param name="klantnummer">Unique identifier for the klant</param>
        public void DeleteWinkelmand(string klantnummer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve the winkelmand for a customer
        /// </summary>
        /// <param name="klantnummer">Unique identifier for the klant</param>
        /// <returns></returns>
        public Winkelmand GetWinkelMand(string klantnummer)
        {
            var proxy = _factory.CreateAgent();
            return proxy.GetWinkelmandje(new PcSWinkelen.V1.Messages.VraagWinkelmandRequestMessage { ClientID = klantnummer }).Winkelmand;
        }
    }
}
