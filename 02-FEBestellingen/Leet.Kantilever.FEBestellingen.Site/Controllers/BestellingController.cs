using Leet.Kantilever.FEBestellingen.Agent;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using minorcase3pcsbestellen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
    [Authorize(Users = @"Minor\Dennis")]
    public class BestellingController : Controller
    {
        private IAgentPcSBestellen _agent;

        public BestellingController()
        {
            _agent = new AgentPcSBestellen();
        }

        public BestellingController(IAgentPcSBestellen agent)
        {
            _agent = agent;
        }

        [Authorize(Users = @"Minor\Dennis")]
        // GET: Bestelling
        public ActionResult Index()
        {
            //var bestellingen = Mapper.MapBestellingToVMList(_agent.FindAllBestellingen());
            var bestellingen = new List<BestellingVM>()
            {
                new BestellingVM
                {
                    Bestellingsregels = new List<BestellingsRegelVM>()
                    {
                        new BestellingsRegelVM
                        {
                            Aantal = 11,
                            Leverancierscode = "AM21",
                            LeveranciersNaam = "Gazelle",
                            Prijs = 21.52M,
                            ProductNaam = "Fiets",
                        }
                    }
                }
            };
            return View(bestellingen);
        }

        [Authorize(Users = @"Minor\Dennis")]
        public ActionResult VolgendeBestelling()
        {
            //var bestelling = Mapper.MapBestellingToVMList(_agent.FindVolgendeOpenBestelling());
            var bestelling = new BestellingVM
            {
                Bestellingsregels = new List<BestellingsRegelVM>()
                    {
                        new BestellingsRegelVM
                        {
                            Aantal = 11,
                            Leverancierscode = "AM21",
                            LeveranciersNaam = "Gazelle",
                            Prijs = 21.52M,
                            ProductNaam = "Fiets",
                        }
                    }

            };
            return View(bestelling.Bestellingsregels);
        }

        [Authorize(Users = @"Minor\Dennis")]
        public ActionResult ToonFactuur(int bestellingID)
        {
            //var factuur = Mapper.BestellingToFactuurVM(_agent.FindBestellingByID(bestellingID));

            BestellingsregelCollection brc = new BestellingsregelCollection();

            brc.Add(new Bestellingsregel
            {
                Aantal = 21,
                Product = new schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product
                {
                    Id = 1,
                    Naam = "HL Road Frame - Black, 58",
                    LeverancierNaam = "Koga Miyata",
                    AfbeeldingURL = "no_image_available_small.gif",
                    Prijs = 1431.50M,
                    Beschrijving = "beschrijving",
                    LeveranciersProductId = "AFSE34D",
                    LeverbaarTot = new DateTime(2017, 3, 12),
                    LeverbaarVanaf = new DateTime(2015, 1, 7),
                }
            });

            var factuur = Mapper.BestellingToFactuurVM(new Bestelling
            {
                Besteldatum = DateTime.Now,
                BestellingsregelCollection = brc,
                Bestelnummer = 12414,
                Klant = new minorcase3bsklantbeheer.v1.schema.Klant
                {
                    Voornaam = "Testdummy",
                    Achternaam = "McNep",
                    Adresregel1 = "Straatlaan 33",
                    Postcode = "1234AB",
                    Woonplaats = "Plaatsnaam",
                    Telefoonnummer = "1234567890",
                    Klantnummer = "1234567890",
                    Gebruikersnaam = "Wololol",
                },
            });
            return View(factuur);
        }
    }
}