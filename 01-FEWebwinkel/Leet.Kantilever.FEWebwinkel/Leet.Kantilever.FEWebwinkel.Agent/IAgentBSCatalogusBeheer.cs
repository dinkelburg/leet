using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.FEWebwinkel.Agent
{
    public interface IAgentBSCatalogusBeheer
    {
        ProductCollection FindProducts(int? page);
    }
}