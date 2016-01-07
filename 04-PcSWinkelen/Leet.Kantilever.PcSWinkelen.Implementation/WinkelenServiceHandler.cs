using Leet.Kantilever.PcSWinkelen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.PcSWinkelen.V1.Messages;

namespace Leet.Kantilever.PcSWinkelen.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WinkelenServiceHandler : IWinkelenService
    {
        public WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {
            throw new NotImplementedException();
        }

        public WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {
            throw new NotImplementedException();
        }
    }
}