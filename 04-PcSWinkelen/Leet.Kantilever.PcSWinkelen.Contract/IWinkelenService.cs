using Leet.Kantilever.PcSWinkelen.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.PcSWinkelen.Contract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWinkelenService
    {
        [OperationContract]
        WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandReqMessage);

        [OperationContract]
        WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage toevoegenWinkelmandReqMessage);

    }
}
