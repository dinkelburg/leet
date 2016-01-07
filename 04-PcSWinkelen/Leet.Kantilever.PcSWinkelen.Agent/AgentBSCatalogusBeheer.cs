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

        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }

        public Product FindProductById(int id)
        {
            using (var p = _factory.CreateAgent() as IDisposable)
            {
                var proxy = p as ICatalogusBeheer;

                var productResult = proxy.FindProductById(new MsgFindProductByIdRequest { Id = id });

                if (productResult.Succes)
                {
                    return productResult.Product;
                }

                return null;
            }
        }
    }
}
