
using Leet.Kantilever.PcSBestellen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.PcSBestellen.V1.Messages;
using Leet.Kantilever.PcSBestellen.Agent;
using Leet.Kantilever.PcSBestellen.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Implementation
{
    public class BestellenServiceHandler : IBestellenService
    {
        private IBSBestellingenbeheerAgent _agent;

        public BestellenServiceHandler()
        {
            _agent = new BSBestellingenbeheerAgent();
        }

        public BestellenServiceHandler(IBSBestellingenbeheerAgent agent)
        {
            _agent = agent;
        }

        public GetAllBestellingenResponseMessage FindAllBestellingen()
        {
            BestellingCollection bestellingen = new BestellingCollection();
            //bestellingen.AddRange(_agent.GetAllBestellingen());
            return new GetAllBestellingenResponseMessage() { Result = bestellingen };
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
