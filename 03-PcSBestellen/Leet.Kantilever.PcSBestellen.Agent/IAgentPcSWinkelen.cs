using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public interface IAgentPcSWinkelen
    {
        /// <summary>
        /// Retrieve the winkelmand for a klant
        /// </summary>
        /// <param name="klantnummer">The klantnummer of the klant</param>
        /// <returns></returns>
        Leet.Kantilever.PcSWinkelen.V1.Schema.Winkelmand GetWinkelMand(string klantnummer);

        /// <summary>
        /// Delete winkelmand for a klant
        /// </summary>
        /// <param name="klantnummer">The klantnummer of the klant</param>
        void RemoveWinkelmand(string klantnummer);
    }
}
