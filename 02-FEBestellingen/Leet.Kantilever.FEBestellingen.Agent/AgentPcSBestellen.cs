﻿using System;
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

        public Bestelling FindBestellingByID(int bestellingID)
        {
            var proxy = _factory.CreateAgent();
            var requestMessage = new GetBestellingByIDRequestMessage
            {
                BestellingsID = bestellingID
            };
            var responseMessage =
            #region tijdelijke mock response message die Klant bevat
                new GetBestellingByIDResponseMessage
            {
                Bestelling = new Bestelling
                {
                    ID = 1,
                    Besteldatum = new System.DateTime(2015, 1, 8),
                    Bestelnummer = 1,
                    BestellingsregelCollection = GetBestellingsRegelCollection(),
                    Klant = new Klant
                    {
                        Voornaam = "Testdummy",
                        Achternaam = "McNep",
                        Adresregel1 = "Straatlaan 33",
                        Postcode = "1234AB",
                        Woonplaats = "Plaatsnaam",
                        Telefoonnummer = "1234567890",
                        Klantnummer = "1234567890",
                        Gebruikersnaam = "Wololol",
                    }
                }
            };
            #endregion//proxy.FindBestellingByID(requestMessage);
            return responseMessage.Bestelling;
        }
    }
}

