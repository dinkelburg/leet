using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.PcSBestellen.Contract
{

    [ServiceContract]
    public interface IBestellenService
    {
        [OperationContract]
        void PlaceHolder();          
    }
}
