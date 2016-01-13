using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.PcSBestellen.V1.Messages;
using Leet.Kantilever.PcSBestellen.Agent;
using Leet.Kantilever.PcSBestellen.V1.Schema;
using Leet.Kantilever.PcSBestellen.Implementation.Mappers;
using Leet.Kantilever.PcSBestellen.Contract;

namespace Leet.Kantilever.PcSBestellen.Implementation
{
    public class BestellenServiceHandler : IBestellenService
    {
        private IBSBestellingenbeheerAgent _agentBestellingen;
        private IAgentBSCatalogusBeheer _agentCatalogus;


        public BestellenServiceHandler()
        {
            _agentBestellingen = new BSBestellingenbeheerAgent();
            _agentCatalogus = new AgentBSCatalogusBeheer();
        }

        public BestellenServiceHandler(IBSBestellingenbeheerAgent agentBestellen, IAgentBSCatalogusBeheer agentCatalogus)
        {
            _agentBestellingen = agentBestellen;
            _agentCatalogus = agentCatalogus;
        }

        public void CreateBestelling(CreateBestellingRequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }

        public GetAllBestellingenResponseMessage FindAllBestellingen()
        {
            //Retrieve all Bestellingen
            var bestellingen = _agentBestellingen.GetAllBestellingen();

            //Convert & get data
            var mapper = new BestellingMapper();
            var bestellingCollection = new BestellingCollection();
            var productIds = new List<int>();
            foreach (var bestelling in bestellingen)
            {
                bestellingCollection.Add(mapper.ConvertToPcsBestelling(bestelling));
                productIds.AddRange(bestelling.Bestellingsregels.Select(r => (int)r.ProductID));
            }

            var producten = _agentCatalogus.GetProductsById(productIds.Distinct().ToArray());

            foreach (var bestelling in bestellingCollection)
            {
                mapper.AddProductsToBestelling(bestelling, producten);
            }

            //Return data
            return new GetAllBestellingenResponseMessage() { BestellingCollection = bestellingCollection };
        }

        public GetBestellingByIDResponseMessage FindBestellingByID(GetBestellingByIDRequestMessage requestMessage)
        {
            //Retrieve all Bestellingen
            var bestelling = _agentBestellingen.GetBestellingByID(requestMessage.BestellingsID);

            //Convert & get data
            var mapper = new BestellingMapper();

            var producten = _agentCatalogus.GetProductsById(
                bestelling.Bestellingsregels.Select(r => (int)r.ProductID)
                .Distinct()
                .ToArray()
            );

            var b = mapper.ConvertToPcsBestelling(bestelling);
            mapper.AddProductsToBestelling(b, producten);
            return new GetBestellingByIDResponseMessage
            {
                Bestelling = b
            };
        }

        public GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling()
        {
            //Quick and dirty fix
            return new GetVolgendeOpenBestellingResponseMessage
            {
                Bestelling = FindAllBestellingen().BestellingCollection.First(),
            };
        }

    }
}
