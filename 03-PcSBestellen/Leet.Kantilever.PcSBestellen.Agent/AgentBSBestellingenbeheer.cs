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
    /// <summary>
    /// See the interface for details.
    /// </summary>
    public class BSBestellingenbeheerAgent : IBSBestellingenbeheerAgent
    {
        private ServiceFactory<IBestellingenbeheerService> _factory;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public BSBestellingenbeheerAgent()
        {
            _factory = new ServiceFactory<IBestellingenbeheerService>("BSBestellingenbeheer");
        }

        /// <summary>
        /// Constructor that accepts a different service factory.
        /// </summary>
        /// <param name="factory"></param>
        public BSBestellingenbeheerAgent(ServiceFactory<IBestellingenbeheerService> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Get bestelling by it's id from BSBestellingenbeheer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bestelling GetBestellingByBestelnummer(long nummer)
        {
            var agent = _factory.CreateAgent();
            
            return agent.FindBestelling(new GetBestellingByBestelnummerRequestMessage { Bestelnummer = nummer }).Bestelling;
        }

        /// <summary>
        /// Get all Bestellingen from BSBestellingenbeheer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Bestelling> GetAllBestellingen()
        {
            var agent = _factory.CreateAgent();
            return agent.FindAllBestelling().BestellingCollection;
        }

        /// <summary>
        /// Get next Bestelling to be packaged from BSBestellingenbeheer
        /// </summary>
        /// <returns></returns>
        public Bestelling GetVolgendeBestelling()
        {
            var agent = _factory.CreateAgent();
            return agent.GetVolgendeOpenBestelling().Bestelling;
        }

        /// <summary>
        /// Create new Bestelling on BSBestellingenbeheer
        /// </summary>
        /// <param name="bestelling"></param>
        public void CreateBestelling(Bestelling bestelling)
        {
            var agent = _factory.CreateAgent();
            agent.CreateBestelling(new CreateBestellingRequestMessage { Bestelling = bestelling });
        }

        /// <summary>
        /// Update bestelling on BSBestellingenbeheer
        /// </summary>
        /// <param name="bestelling"></param>
        public void UpdateBestelling(Bestelling bestelling)
        {
            var agent = _factory.CreateAgent();
            agent.UpdateBestelling(new UpdateBestellingRequestMessage { Bestelling = bestelling });
        }
    }
}
