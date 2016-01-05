using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.BSKlantbeheer.Contract
{
    [ServiceContract]
    public interface IKlantbeheerService
    {
        [OperationContract]
        string GetData(int value);
    }
    
}
