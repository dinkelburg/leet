using System.Collections.Generic;
using Kantilever.BsCatalogusbeheer.Product.V1;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    /// <summary>
    /// The interface for the BSCatalogusBeheer service.
    /// </summary>
    public interface IAgentBSCatalogusBeheer
    {
        /// <summary>
        /// Returns a series of products.
        /// </summary>
        /// <param name="ids">The ID's of the products to be returned.</param>
        /// <returns></returns>
        IEnumerable<Product> GetProductsById(int[] ids);
    }
}