using Kantilever.BsCatalogusbeheer.V1;
using Kantilever.BsCatalogusbeheer.Messages.V1;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.PcSWinkelen.Agent
{
    public class AgentBSCatalogusBeheer : IAgentBSCatalogusBeheer
    {
        private ServiceFactory<ICatalogusBeheer> _factory;

        /// <summary>
        /// Constructor to instantiate AgentBSCatalogusBeheer with a SerciceFactory
        /// </summary>
        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }

        /// <summary>
        /// Constructor to instantiate AgentBSCatalogusBeheer and to inject a SerciceFactory mock
        /// </summary>
        /// <param name="factory">ServiceFactory mock</param>
        public AgentBSCatalogusBeheer(ServiceFactory<ICatalogusBeheer> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Find a product by id in the BSCatalogusBeheer
        /// </summary>
        /// <param name="id">Id of product</param>
        /// <returns>The product that matches the given id</returns>
        public Product FindProductById(int id)
        {
            var proxy = _factory.CreateAgent();

            var productResult = proxy.FindProductById(new MsgFindProductByIdRequest { Id = id });

            if (productResult.Succes)
            {
                return productResult.Product;
            }

            return null;
        }
    }
}
