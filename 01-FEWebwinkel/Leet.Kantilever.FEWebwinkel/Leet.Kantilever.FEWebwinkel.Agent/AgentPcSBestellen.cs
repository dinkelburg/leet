using Minor.Case3.BsKlantbeheer.V1.Schema;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.FEWebwinkel.Agent
{
    public class AgentPcSBestellen : IAgentPcSBestellen
    {
        private ServiceFactory<IBestellenService> _factory;

        public AgentPcSBestellen()
        {
            _factory = new ServiceFactory<IBestellenService>("PcSBestellen");
        }

        public void CreateBestelling(Klant klant)
        {
            AutoMapper.Mapper.CreateMap<Klant, minorcase3bsklantbeheer.v1.schema.Klant>();
            var proxy = _factory.CreateAgent();
            var k = AutoMapper.Mapper.Map<minorcase3bsklantbeheer.v1.schema.Klant>(klant);
            proxy.CreateBestelling(new minorcase3pcsbestellen.v1.messages.CreateBestellingRequestMessage
            {
                Klant = k,
            });
        }

    }
}
