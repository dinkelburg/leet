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
        Bestelling GetBestellingByBestelnummer(long id);

        /// <summary>
        /// Returns the next bestelling to be handled.
        /// </summary>
        /// <returns></returns>
        Bestelling GetVolgendeBestelling();

        /// <summary>
        /// Create a new bestelling
        /// </summary>
        /// <param name="bestelling"></param>
        void CreateBestelling(Bestelling bestelling);

        void UpdateBestelling(Bestelling bestelling);

        /// <summary>
        /// Get all Bestellingen that are placed by this Klant
        /// </summary>
        /// <param name="klantnummer"></param>
        /// <returns>BestellingCollection containing all Bestellingen that belong to this Klant</returns>
        BestellingCollection GetAllBestellingenByKlant(string klantnummer);
    }
}