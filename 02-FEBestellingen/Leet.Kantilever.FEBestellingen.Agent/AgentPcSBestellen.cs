using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minorcase3pcsbestellen.v1.schema;
using Minor.ServiceBus.Agent.Implementation;
using minorcase3pcsbestellen.v1.messages;
using minorcase3bsklantbeheer.v1.schema;

namespace Leet.Kantilever.FEBestellingen.Agent
{
    //See the interface for details.
    public class AgentPcSBestellen : IAgentPcSBestellen
    {
        private ServiceFactory<IBestellenService> _factory;

        public AgentPcSBestellen()
        {
            _factory = new ServiceFactory<IBestellenService>("PcSBestellen");
        }

        public AgentPcSBestellen(ServiceFactory<IBestellenService> factory)
        {
            _factory = factory;
        }

        public BestellingCollection FindAllBestellingen()
        {
            var proxy = _factory.CreateAgent();
            var getBestellingenResponseMessage = proxy.FindAllBestellingen();
            return getBestellingenResponseMessage.BestellingCollection;
        }

        public Bestelling FindVolgendeOpenBestelling()
        {
            var proxy = _factory.CreateAgent();
            var bestelling = proxy.FindVolgendeOpenBestelling();
            return bestelling.Bestelling;
        }

        public Bestelling FindBestellingByBestelnummer(long bestelnummer)
        {
            var proxy = _factory.CreateAgent();
            var requestMessage = new GetBestellingByIDRequestMessage
            {
                BestellingsID = bestelnummer
            };
            var responseMessage = proxy.FindBestellingByBestelnummer(requestMessage);
            return responseMessage.Bestelling;
        }

        public void UpdateBestelling(Bestelling bestelling)
        {
            var proxy = _factory.CreateAgent();
            bestelling.Klant = new Klant
            {
                Voornaam = "Testdummy",
                Achternaam = "McNep",
                Adresregel1 = "Straatlaan 33",
                Postcode = "1234AB",
                Woonplaats = "Plaatsnaam",
                Telefoonnummer = "1234567890",
                Klantnummer = "1234567890",
                Gebruikersnaam = "Wololol",
            };
            proxy.UpdateBestelling(new UpdateBestellingRequestMessage { Bestelling = bestelling });
        }
    }
}

