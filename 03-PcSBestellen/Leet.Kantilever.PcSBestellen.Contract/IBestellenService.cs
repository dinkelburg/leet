using Leet.Kantilever.PcSBestellen.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.PcSBestellen.Contract
{
    /// <summary>
    /// The interface for the service. The frontends call this interface.
    /// </summary>
    [ServiceContract(Namespace = "urn:leet:kantilever:pcsbestellen:v1")]
    public interface IBestellenService
    {
        /// <summary>
        /// Finds the first bestelling that hasn't been handled yet.
        /// </summary>
        /// <returns>A bestelling.</returns>
        [OperationContract]
        GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling();

        /// <summary>
        /// Returns all bestellingen that haven't been handled yet.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetAllBestellingenResponseMessage FindAllBestellingen();

        /// <summary>
        /// Find a specific bestelling.
        /// </summary>
        /// <param name="requestMessage">The ID of the bestelling to find.</param>
        /// <returns></returns>
        [OperationContract]
        GetBestellingByIDResponseMessage FindBestellingByBestelnummer(GetBestellingByIDRequestMessage requestMessage);

        /// <summary>
        /// Create new bestelling
        /// </summary>
        /// <param name="requestMessage"></param>
        [OperationContract]
        void CreateBestelling(CreateBestellingRequestMessage requestMessage);

        /// <summary>
        /// Update bestelling information
        /// </summary>
        /// <param name="requestMessage"></param>
        [OperationContract]
        void UpdateBestelling(UpdateBestellingRequestMessage requestMessage);
    }
}
