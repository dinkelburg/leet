using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public interface IAgentBSBestellingenbeheer
    {
        IEnumerable<Bestelling> GetAllBestellingen();
        Bestelling GetBestellingByID(long id);
        Bestelling GetVolgendeBestelling();
    }
}