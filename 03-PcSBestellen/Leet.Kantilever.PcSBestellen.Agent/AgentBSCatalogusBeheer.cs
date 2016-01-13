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
    public class AgentBSCatalogusBeheer : IAgentBSCatalogusBeheer
    {
        private ServiceFactory<ICatalogusBeheer> _factory;

        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }

        public AgentBSCatalogusBeheer(ServiceFactory<ICatalogusBeheer> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Get a collection of Products with the ID's that belong to them
        /// </summary>
        /// <param name="ids">ID's of the corresponding products</param>
        /// <returns></returns>
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
