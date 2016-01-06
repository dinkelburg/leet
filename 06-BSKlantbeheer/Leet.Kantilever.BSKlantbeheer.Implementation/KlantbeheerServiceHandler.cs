using Leet.Kantilever.BSKlantbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.BSKlantbeheer.Implementation
{
    public class KlantbeheerServiceHandler : IKlantbeheerService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
