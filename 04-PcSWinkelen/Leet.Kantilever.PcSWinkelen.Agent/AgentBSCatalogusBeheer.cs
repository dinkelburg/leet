using Kantilever.BsCatalogusbeheer.Messages.V1;
using Minor.ServiceBus.Agent.Implementation;
using Kantilever.BsCatalogusbeheer.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using System;

namespace Leet.Kantilever.PcSWinkelen.Agent
{
    public class AgentBSCatalogusBeheer
    {
        private ServiceFactory<ICatalogusBeheer> _factory;

        public AgentBSCatalogusBeheer()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
        }
        
        public Product FindProductByID(int productID)
        {
            using (var p = _factory.CreateAgent() as IDisposable)
            {
                var proxy = p as ICatalogusBeheer;
                var responseMessage = proxy.FindProductById(new MsgFindProductByIdRequest
                {
                    Id = productID,
                });

                return responseMessage.Product;
            }

        }

    }
}
