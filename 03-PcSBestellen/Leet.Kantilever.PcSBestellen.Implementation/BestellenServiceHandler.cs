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
using minorcase3bsklantbeheer.v1.schema;
using AutoMapper;
using System.Configuration;

namespace Leet.Kantilever.PcSBestellen.Implementation
{
    /// <summary>
    /// See the interface for details.
    /// </summary>
    public class BestellenServiceHandler : IBestellenService
    {
        private IBSBestellingenbeheerAgent _agentBestellingen;
        private IAgentBSCatalogusBeheer _agentCatalogus;
        private IAgentPcSWinkelen _agentWinkelen;
        private IAgentBSKlantbeheer _agentKlant;


        public BestellenServiceHandler()
        {
            _agentBestellingen = new BSBestellingenbeheerAgent();
            _agentCatalogus = new AgentBSCatalogusBeheer();
            _agentWinkelen = new AgentPcSWinkelen();
            _agentKlant = new AgentBSKlantbeheer();
        }

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="agentBestellen"></param>
        /// <param name="agentCatalogus"></param>
        /// <param name="agentWinkelen"></param>
        public BestellenServiceHandler(IBSBestellingenbeheerAgent agentBestellen, IAgentBSCatalogusBeheer agentCatalogus, IAgentPcSWinkelen agentWinkelen, IAgentBSKlantbeheer agentKlant)
        {
            _agentBestellingen = agentBestellen;
            _agentCatalogus = agentCatalogus;
            _agentWinkelen = agentWinkelen;
            _agentKlant = agentKlant;
        }


        /// <summary>
        /// Update bestelling information
        /// </summary>
        /// <param name="requestMessage"></param>
        public void UpdateBestelling(UpdateBestellingRequestMessage requestMessage)
        {
            var bestelling = BestellingMapper.ConvertToBSBestelling(requestMessage.Bestelling);
            _agentBestellingen.UpdateBestelling(bestelling);
        }

        /// <summary>
        /// Create a bestelling for a klant using his current winkelmand
        /// </summary>
        /// <param name="requestMessage"></param>
        public void CreateBestelling(CreateBestellingRequestMessage requestMessage)
        {
            var winkelmand = _agentWinkelen.GetWinkelMand(requestMessage.Klant.Klantnummer);
            var bestelling = BestellingMapper.ConvertWinkelmandToBestelling(winkelmand);

            bestelling.Besteldatum = DateTime.Now;
            bestelling.Klant = requestMessage.Klant;
            bestelling.Status = BepaalStatusVoorBestelling(bestelling, requestMessage.Klant);

            Mapper.CreateMap<Klant, BSKlantbeheer.V1.Schema.Klant>();
            _agentKlant.RegistreerKlant(Mapper.Map<BSKlantbeheer.V1.Schema.Klant>(bestelling.Klant));

            _agentBestellingen.CreateBestelling(BestellingMapper.ConvertToBSBestelling(bestelling));
            
            //Remove winkelmand
            _agentWinkelen.RemoveWinkelmand(bestelling.Klant.Klantnummer);
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
            var bestellingCollection = new BestellingCollection();
            var productIds = new List<int>();
            foreach (var bestelling in bestellingen)
            {
                bestellingCollection.Add(BestellingMapper.ConvertToPcsBestelling(bestelling));
                productIds.AddRange(bestelling.Bestellingsregels.Select(r => (int)r.ProductID));
            }

            var producten = _agentCatalogus.GetProductsById(productIds.Distinct().ToArray());

            foreach (var bestelling in bestellingCollection)
            {
                BestellingMapper.AddProductsToBestelling(bestelling, producten);
            }

            //Return data
            return new GetAllBestellingenResponseMessage() { BestellingCollection = bestellingCollection };
        }

        /// <summary>
        /// Find a specific bestelling by id
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public GetBestellingByIDResponseMessage FindBestellingByBestelnummer(GetBestellingByIDRequestMessage requestMessage)
        {
            //Retrieve all Bestellingen
            var agentBestelling = _agentBestellingen.GetBestellingByBestelnummer(requestMessage.BestellingsID);

            //Convert & get data
            var producten = _agentCatalogus.GetProductsById(
                agentBestelling.Bestellingsregels.Select(r => (int)r.ProductID)
                .Distinct()
                .ToArray()
            );
            
            var bestelling = BestellingMapper.ConvertToPcsBestelling(agentBestelling);

            var agentKlant = _agentKlant.GetKlant(agentBestelling.Klantnummer);
            bestelling.Klant = BestellingMapper.ConvertToBSKlant(agentKlant);
            BestellingMapper.AddProductsToBestelling(bestelling, producten);
            return new GetBestellingByIDResponseMessage
            {
                Bestelling = bestelling
            };
        }

        /// <summary>
        /// Find the next Bestelling to be packaged
        /// </summary>
        /// <returns>Bestelling</returns>
        public GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling()
        {
           
            var bsBestelling = _agentBestellingen.GetVolgendeBestelling();
            var pcsBestelling = BestellingMapper.ConvertToPcsBestelling(bsBestelling);

            var producten = _agentCatalogus.GetProductsById(
                bsBestelling.Bestellingsregels.Select(r => (int)r.ProductID)
                .Distinct()
                .ToArray()
            );

            BestellingMapper.AddProductsToBestelling(pcsBestelling, producten);

            return new GetVolgendeOpenBestellingResponseMessage
            {
                Bestelling = pcsBestelling
            };
        }
        
        /// <summary>
        /// Get the right Status for this bestelling
        /// </summary>
        /// <param name="bestelling">The new Bestelling that needs a check</param>
        /// <param name="klant">The Klant that placed the Bestelling</param>
        /// <returns></returns>
        public minorcase3bsbestellingenbeheer.v1.schema.Bestellingsstatus BepaalStatusVoorBestelling(V1.Schema.Bestelling bestelling, Klant klant)
        {
            decimal totaalPrijsBestelling = bestelling.BestellingsregelCollection.Sum
                    (bestellingsregel => bestellingsregel.Product.Prijs.Value * bestellingsregel.Aantal);
            decimal totaalOpenBestellingen = 0;   //Wacht op interface van Bas
            int limiet;
            int.TryParse(ConfigurationManager.AppSettings["limiet"], out limiet);

            if (totaalPrijsBestelling + totaalOpenBestellingen > limiet)
            {
                return minorcase3bsbestellingenbeheer.v1.schema.Bestellingsstatus.Nieuw;
            }
            else
            {
                return minorcase3bsbestellingenbeheer.v1.schema.Bestellingsstatus.Goedgekeurd;
            }
        }
    }
}
