using Leet.Kantilever.BSKlantbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.BSKlantbeheer.V1.Messages;

namespace Leet.Kantilever.BSKlantbeheer.Implementation
{
    public class KlantbeheerServiceHandler : IKlantbeheerService
    {
        public GetAllKlantenResponseMessage GetAllKlanten()
        {
            throw new NotImplementedException();
        }

        public GetKlantByKlantnummerResponseMessage GetKlant(GetKlantByKlantnummerRequestMessage msg)
        {
            throw new NotImplementedException();
        }

        public void RegistreerKlant(InsertKlantGegevensRequestMessage msg)
        {
            throw new NotImplementedException();
        }
    }
}
