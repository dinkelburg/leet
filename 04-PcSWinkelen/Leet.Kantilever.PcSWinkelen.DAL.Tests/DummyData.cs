using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL.Tests
{
    public static class DummyData
    {
        public static Product GetProduct()
        {
            return new Product
            {
                AfbeeldingURL = "img.jpg",
                Beschrijving = "beschrijving",
                LeverancierNaam = "Gazelle",
                LeveranciersProductId = "AFSE34D",
                LeverbaarTot = new DateTime(2017, 3, 12),
                LeverbaarVanaf = new DateTime(2015, 1, 7),
                Naam = "Product Naam",
                Prijs = 123.54M,
                ClientId = "ID01"
            };
        }

        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    AfbeeldingURL = "img.jpg",
                    Beschrijving = "beschrijving",
                    LeverancierNaam = "Gazelle",
                    LeveranciersProductId = "AFSE34D",
                    LeverbaarTot = new DateTime(2017, 3, 12),
                    LeverbaarVanaf = new DateTime(2015, 1, 7),
                    Naam = "Product Naam",
                    Prijs = 123.54M,
                    ClientId = "ID01",
                },
                new Product
                {
                    AfbeeldingURL = "img1.jpg",
                    Beschrijving = "beschrijving1",
                    LeverancierNaam = "Gazelle",
                    LeveranciersProductId = "AFSE34F",
                    LeverbaarTot = new DateTime(2017, 3, 12),
                    LeverbaarVanaf = new DateTime(2015, 1, 7),
                    Naam = "Product Naam1",
                    Prijs = 125.54M,
                    ClientId = "ID01",
                },
            };
        }
    }
}
