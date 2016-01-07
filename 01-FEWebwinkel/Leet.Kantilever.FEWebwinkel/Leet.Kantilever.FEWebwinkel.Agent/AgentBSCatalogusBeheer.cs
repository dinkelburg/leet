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

        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }

        public AgentBSCatalogusBeheer(ServiceFactory<ICatalogusBeheer> factory)
        {
            _factory = factory;
        }

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
