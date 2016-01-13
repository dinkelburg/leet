using System.Collections.Generic;
using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public interface IAgentBSCatalogusBeheer
    {
        IEnumerable<Product> GetProductsById(int[] ids);
    }
}