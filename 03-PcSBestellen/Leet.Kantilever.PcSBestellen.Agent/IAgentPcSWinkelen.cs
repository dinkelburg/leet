using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public interface IAgentPcSWinkelen
    {
        Leet.Kantilever.PcSWinkelen.V1.Schema.Winkelmand GetWinkelMand(string klantnummer);

        void DeleteWinkelmand(string klantnummer);
    }
}
