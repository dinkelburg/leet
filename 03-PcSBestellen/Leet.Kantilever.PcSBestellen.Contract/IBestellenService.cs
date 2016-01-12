using Leet.Kantilever.PcSBestellen.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.PcSBestellen.Contract
{

    [ServiceContract(Namespace = "urn:leet:kantilever:pcsbestellen:v1")]
    public interface IBestellenService
    {
        [OperationContract]
        GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling();

        [OperationContract]
        GetAllBestellingenResponseMessage FindAllBestellingen();

        [OperationContract]
        GetBestellingByIDResponseMessage FindBestellingByID(GetBestellingByIDRequestMessage requestMessage);
    }
}
