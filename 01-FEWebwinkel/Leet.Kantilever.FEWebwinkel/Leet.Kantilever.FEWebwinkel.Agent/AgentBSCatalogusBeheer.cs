using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using Kantilever.BsCatalogusbeheer.V1;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEWebwinkel.Agent
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
        /// Get All product on a page in the BSCatalogusBeheer
        /// </summary>
        /// <param name="page">Page of the collection</param>
        /// <returns>ProductCollection on the given page</returns>
        public ProductCollection FindProducts(int? page)
        {
            var proxy = _factory.CreateAgent();
            var productCollection = proxy.FindProducts(new MsgFindProductsRequest
            {
                Page = page.HasValue ? page.Value : 1,
                PageSize = 12,
            });
            return productCollection.Products;

        }
    }
}
