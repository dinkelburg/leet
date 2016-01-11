
using Leet.Kantilever.PcSBestellen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.PcSBestellen.V1.Messages;

namespace Leet.Kantilever.PcSBestellen.Implementation
{

    public class BestellenServiceHandler : IBestellenService
    {
        public GetAllBestellingenResponseMessage FindAllBestellingen()
        {
            throw new NotImplementedException();
        }

        public GetBestellingByIDResponseMessage FindBestellingByID(GetBestellingByIDRequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }

        public GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling()
        {
            throw new NotImplementedException();
        }

    }
}
