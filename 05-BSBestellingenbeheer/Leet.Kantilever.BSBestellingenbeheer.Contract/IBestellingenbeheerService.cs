using Leet.Kantilever.BSBestellingenbeheer.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.BSBestellingenbeheer.Contract
{
    [ServiceContract(Namespace = "urn:leet:kantilever:bsbestellingenbeheer:v1")]
    public interface IBestellingenbeheerService
    {
        [OperationContract]
        GetBestellingByBestelnummerResponseMessage FindBestelling(GetBestellingByBestelnummerRequestMessage requestMessage);

        [OperationContract]
        GetAllBestellingenResponseMessage FindAllBestelling();

        [OperationContract]
        GetVolgendeOpenBestellingResponseMessage GetVolgendeOpenBestelling();
        
        [OperationContract]
        void CreateBestelling(CreateBestellingRequestMessage requestMesssage);

        [OperationContract]
        void UpdateBestelling(UpdateBestellingRequestMessage requestMessage);

        [OperationContract]
        GetAllBestellingenByKlantResponseMessage GetAllBestellingenByKlant(GetAllBestellingenByKlantRequestMessage requestMessage);
    }
}
