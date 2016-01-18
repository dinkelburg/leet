using Leet.Kantilever.BSKlantbeheer.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.BSKlantbeheer.Contract
{
    [ServiceContract(Namespace = "urn:leet:kantilever:bsklantbeheer:v1")]
    public interface IKlantbeheerService
    {
        /// <summary>
        /// Returns all klanten.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetAllKlantenResponseMessage GetAllKlanten();

        /// <summary>
        /// Returns a specific klant.
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        [OperationContract]
        GetKlantByKlantnummerResponseMessage GetKlant(GetKlantByKlantnummerRequestMessage requestMessage);

        /// <summary>
        /// Insert a new klant into the database.
        /// </summary>
        /// <param name="requestMessage"></param>
        [OperationContract]
        void RegistreerKlant(InsertKlantGegevensRequestMessage requestMessage);
    }
}
