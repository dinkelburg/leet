using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public interface IAgentBSKlantbeheer
    {
        void RegistreerKlant(Klant klant);
        Klant GetKlant(string klantnummer);
    }
}
