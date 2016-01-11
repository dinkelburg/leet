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
        GetBestellingByIDResponseMessage FindBestelling(GetBestellingByIDRequestMessage m);

        GetAllBestellingenResponseMessage FindAllBestelling();


    }
}
