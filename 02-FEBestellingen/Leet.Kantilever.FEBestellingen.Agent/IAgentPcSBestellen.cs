using minorcase3pcsbestellen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEBestellingen.Agent
{
    public interface IAgentPcSBestellen
    {
        BestellingCollection FindAllBestellingen();
        Bestelling FindBestellingByBestelnummer(long bestellingID);

        Bestelling FindVolgendeOpenBestelling();

        void UpdateBestelling(Bestelling bestelling);
        IEnumerable<Bestelling> FindAllNewBestellingen();
    }
}
