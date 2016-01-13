using Leet.Kantilever.PcSWinkelen.V1.Messages;
using Minor.case3.Leet.V1.FunctionalError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.PcSWinkelen.Contract
{
    [ServiceContract(Namespace = "urn:kantilever:pcswinkelen:v1")]
    public interface IWinkelenService
    {
        [OperationContract]
        [FaultContract(typeof(FunctionalErrorList))]
        WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandReqMessage);

        [OperationContract]
        [FaultContract(typeof(FunctionalErrorList))]
        WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage vraagWinkelmandReqMessage);

    }
}
