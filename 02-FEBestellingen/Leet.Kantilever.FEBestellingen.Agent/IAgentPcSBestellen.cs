using minorcase3pcsbestellen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEBestellingen.Agent
{
    /// <summary>
    /// Interface that details how the PcSBestellen service is implemented.
    /// </summary>
    public interface IAgentPcSBestellen
    {
        /// <summary>
        /// Returns all bestellingen.
        /// </summary>
        /// <returns></returns>
        BestellingCollection FindAllBestellingen();

        /// <summary>
        /// Returns a bestelling based on its bestellingID
        /// </summary>
        /// <param name="bestellingID"></param>
        /// <returns></returns>
        Bestelling FindBestellingByBestelnummer(long bestellingID);

        /// <summary>
        /// Find any bestelling that hasn't been packed yet.
        /// </summary>
        /// <returns></returns>
        Bestelling FindVolgendeOpenBestelling();

        /// <summary>
        /// Updates a bestelling. Used to indicate a bestelling has been packed.
        /// </summary>
        /// <param name="bestelling"></param>
        void UpdateBestelling(Bestelling bestelling);
    }
}
