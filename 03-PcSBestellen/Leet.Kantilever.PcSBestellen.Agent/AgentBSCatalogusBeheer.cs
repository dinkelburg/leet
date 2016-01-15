using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using Kantilever.BsCatalogusbeheer.V1;
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
    public class AgentBSCatalogusBeheer : IAgentBSCatalogusBeheer
    {
        private ServiceFactory<ICatalogusBeheer> _factory;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }

        /// <summary>
        /// A constructor that accepts a different service factory.
        /// </summary>
        /// <param name="factory"></param>
        public AgentBSCatalogusBeheer(ServiceFactory<ICatalogusBeheer> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Product> GetProductsById(int[] ids)
        {
            List<Product> products = new List<Product>();
            var agent = _factory.CreateAgent();
            foreach(int id in ids)
            {
                var msg = new MsgFindProductByIdRequest() { Id = id };
                var result = _factory.CreateAgent().FindProductById(msg);
                if (result.Succes)
                {
                    products.Add(result.Product);
                }
                else
                {
                    throw new KeyNotFoundException(result.Foutmelding.Melding);
                }
            }
            return products;            
        }
    }
}
