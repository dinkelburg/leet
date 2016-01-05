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
    public class AgentBSCatalogusBeheer
    {
        private ServiceFactory<ICatalogusBeheer> _factory;

        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }

        public ProductCollection FindAllProducts()
        {
            var proxy = _factory.CreateAgent();
            var productCollection = proxy.FindProducts(new MsgFindProductsRequest
            {
                Page = 1,
                PageSize = 10,
            });

            return productCollection.Products;
        }
    }
}
