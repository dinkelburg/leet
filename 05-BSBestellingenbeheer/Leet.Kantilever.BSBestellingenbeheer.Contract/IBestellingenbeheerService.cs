using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.BSBestellingenbeheer.Contract
{
    [ServiceContract]
    public interface IBestellingenbeheerService
    {
        [OperationContract]
        string GetData(int value);

    }
}
