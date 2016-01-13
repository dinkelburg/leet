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
        [OperationContract]
        GetAllKlantenResponseMessage GetAllKlanten();
        [OperationContract]
        GetKlantByKlantnummerResponseMessage GetKlant(GetKlantByKlantnummerRequestMessage msg);
        [OperationContract]
        void RegistreerKlant(InsertKlantGegevensRequestMessage msg);
    }
}
