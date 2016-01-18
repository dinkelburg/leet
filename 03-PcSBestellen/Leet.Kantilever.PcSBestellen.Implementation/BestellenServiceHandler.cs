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


        public BestellenServiceHandler()
        {
            _agentBestellingen = new BSBestellingenbeheerAgent();
            _agentCatalogus = new AgentBSCatalogusBeheer();
            _agentWinkelen = new AgentPcSWinkelen();
        }

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="agentBestellen"></param>
        /// <param name="agentCatalogus"></param>
        /// <param name="agentWinkelen"></param>
        public BestellenServiceHandler(IBSBestellingenbeheerAgent agentBestellen, IAgentBSCatalogusBeheer agentCatalogus, IAgentPcSWinkelen agentWinkelen)
        {
            _agentBestellingen = agentBestellen;
            _agentCatalogus = agentCatalogus;
            _agentWinkelen = agentWinkelen;
        }


        /// <summary>
        /// Update bestelling information
        /// </summary>
        /// <param name="requestMessage"></param>
        public void UpdateBestelling(UpdateBestellingRequestMessage requestMessage)
        {
            var mapper = new BestellingMapper();
            var bestelling = mapper.ConvertToBSBestelling(requestMessage.Bestelling);
            _agentBestellingen.UpdateBestelling(bestelling);
        }

        /// <summary>
        /// Create a bestelling for a klant using his current winkelmand
        /// </summary>
        /// <param name="requestMessage"></param>
        public void CreateBestelling(CreateBestellingRequestMessage requestMessage)
        {
            var winkelmand = _agentWinkelen.GetWinkelMand(requestMessage.Klant.Klantnummer);
            var mapper = new BestellingMapper();
            var bestelling = mapper.ConvertWinkelmandToBestelling(winkelmand);

            bestelling.Besteldatum = DateTime.Now;
            bestelling.Klant = requestMessage.Klant;

            //TODO: Save customer information in a future sprint.

            _agentBestellingen.CreateBestelling(mapper.ConvertToBSBestelling(bestelling));
            
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

        /// <summary>
        /// Find a specific bestelling by id
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public GetBestellingByIDResponseMessage FindBestellingByBestelnummer(GetBestellingByIDRequestMessage requestMessage)
        {
            //Retrieve all Bestellingen
            var bestelling = _agentBestellingen.GetBestellingByBestelnummer(requestMessage.BestellingsID);

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
        /// Find the next Bestelling to be packaged
        /// </summary>
        /// <returns>Bestelling</returns>
        public GetVolgendeOpenBestellingResponseMessage FindVolgendeOpenBestelling()
        {
            BestellingsregelCollection c = new BestellingsregelCollection();
            c.Add(new Bestellingsregel
            {
                Aantal =10,
                Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                {
                    AfbeeldingURL = "/images/product.jpg",
                    Beschrijving = "Blauwe fiets",
                    Id = 154,
                    LeverancierNaam = "De Boer Fietsen",
                    LeveranciersProductId = "DBF10254632",
                    LeverbaarTot = null,
                    LeverbaarVanaf = new DateTime(2003, 2, 14),
                    Naam = "Fiets F1024",
                    Prijs = 299.99M,
                    CategorieLijst = new schemaswwwkantilevernl.bscatalogusbeheer.categorie.v1.CategorieCollection()
                }
            });
            //return new GetVolgendeOpenBestellingResponseMessage
            //{
            //    Bestelling = new Bestelling
            //    {
            //        Besteldatum = DateTime.Now,
            //        Bestelnummer = 1,
            //        ID = 1,
            //        BestellingsregelCollection = c,
            //        Klant = new Klant
            //        {
            //            Voornaam = "Testdummy",
            //            Achternaam = "McNep",
            //            Adresregel1 = "Straatlaan 33",
            //            Postcode = "1234AB",
            //            Woonplaats = "Plaatsnaam",
            //            Telefoonnummer = "1234567890",
            //            Klantnummer = "1234567890",
            //            Gebruikersnaam = "Wololol",
            //            ID = 1,
            //        }

            //    }
            //};
            BestellingMapper mapper = new BestellingMapper();
            var bsBestelling = _agentBestellingen.GetVolgendeBestelling();
            var pcsBestelling = mapper.ConvertToPcsBestelling(bsBestelling);

            var producten = _agentCatalogus.GetProductsById(
                bsBestelling.Bestellingsregels.Select(r => (int)r.ProductID)
                .Distinct()
                .ToArray()
            );

            mapper.AddProductsToBestelling(pcsBestelling, producten);

            pcsBestelling.Klant = new Klant
            {
                Voornaam = "Testdummy",
                Achternaam = "McNep",
                Adresregel1 = "Straatlaan 33",
                Postcode = "1234AB",
                Woonplaats = "Plaatsnaam",
                Telefoonnummer = "1234567890",
                Klantnummer = "1234567890",
                Gebruikersnaam = "Wololol",
                ID = 1,
            };

            return new GetVolgendeOpenBestellingResponseMessage
            {
                Bestelling = pcsBestelling
            };
        }

    }
}
