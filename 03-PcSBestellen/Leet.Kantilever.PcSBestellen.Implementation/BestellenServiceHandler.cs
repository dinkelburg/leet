﻿
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
using Leet.Kantilever.PcSBestellen.Implementation.Mappers;


namespace Leet.Kantilever.PcSBestellen.Implementation
{
    public class BestellenServiceHandler : IBestellenService
    {
        private IAgentBSBestellingenbeheer _agentBestellingen;
        private IAgentBSCatalogusBeheer _agentCatalogus;


        public BestellenServiceHandler()
        {
            _agentBestellingen = new AgentBSBestellingenbeheer();
            _agentCatalogus = new AgentBSCatalogusBeheer();
        }

        public BestellenServiceHandler(IAgentBSBestellingenbeheer agentBestellen, IAgentBSCatalogusBeheer agentCatalogus)
        {
            _agentBestellingen = agentBestellen;
            _agentCatalogus = agentCatalogus;
        }

        /// <summary>
        /// Retrieve all bestellingen from the BSBestellingenbeheer service and add product information from the BSCatalogusbeheer
        /// </summary>
        /// <returns></returns>
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
            return new GetAllBestellingenResponseMessage() { Result = bestellingCollection };
        }

        /// <summary>
        /// Find a specific bestelling by id
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Find the next bestelling to be packaged
        /// </summary>
        /// <returns></returns>
        public GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling()
        {
            //Quick and dirty fix
            return new GetVolgendeOpenBestellingResponseMessage
            {
                Bestelling = FindAllBestellingen().Result.First()
            };
        }

    }
}
