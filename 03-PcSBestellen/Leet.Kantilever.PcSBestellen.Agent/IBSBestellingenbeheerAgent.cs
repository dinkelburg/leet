using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    /// <summary>
    /// The interface for the BSBestellingbeheer service.
    /// </summary>
    public interface IBSBestellingenbeheerAgent
    {
        /// <summary>
        /// Returns all bestellingen that haven't been handled yet.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Bestelling> GetAllBestellingen();

        /// <summary>
        /// Returns a specific bestelling.
        /// </summary>
        /// <param name="id">The ID of the bestelling to return.</param>
        /// <returns></returns>
        Bestelling GetBestellingByID(long id);
    }
}