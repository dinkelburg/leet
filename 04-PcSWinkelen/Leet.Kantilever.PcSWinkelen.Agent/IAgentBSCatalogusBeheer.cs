using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.PcSWinkelen.Agent
{
    public interface IAgentBSCatalogusBeheer
    {
        Product FindProductById(int id);
    }
}