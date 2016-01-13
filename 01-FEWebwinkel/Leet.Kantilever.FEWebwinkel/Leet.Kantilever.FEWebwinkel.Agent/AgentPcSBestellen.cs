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
        //private ServiceFactory<IPcSBestellen> _factory;

        public AgentPcSBestellen()
        {
            //_factory = new ServiceFactory<IPcSBestellen>("PcSBestellen");
        }

        public void KlantGegevensInvoeren(Klant klant)
        {

        } 
    }
}
