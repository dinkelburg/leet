using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL.Tests
{
    /// <summary>
    /// This class provides dummy data for test purposes
    /// </summary>
    public static class DummyDataDAL
    {
        /// <summary>
        /// Dummy data for Product 
        /// </summary>
        /// <returns>Dummy Product</returns>
        public static Product GetProduct()
        {
            return new Product
            {
                AfbeeldingURL = "img1.jpg",
                Beschrijving = "beschrijving product",
                LeverancierNaam = "Trek",
                LeveranciersProductId = "Z21OP",
                LeverbaarTot = new DateTime(2019, 5, 1),
                LeverbaarVanaf = new DateTime(2014, 2, 9),
                Naam = "Product Naam Z21OP",
                Prijs = 12.16M,
                Aantal = 1,
                CatalogusProductID = 1,
            };
        }

        /// <summary>
        /// Dummy data for a list of Products 
        /// </summary>
        /// <returns>Dummy list of Products</returns>
        public static ICollection<Product> GetProducts()
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
                    Aantal = 1,
                    CatalogusProductID = 2,
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
                    Aantal = 1,
                    CatalogusProductID = 3,
                },
            };
        }

        /// <summary>
        /// Dummy data for a Winkelmand
        /// </summary>
        /// <returns>Dummy Winkelmand</returns>
        public static Winkelmand GetWinkelmand()
        {
            return new Winkelmand
            {
                ClientID = "Client01",
                Products = GetProducts(),
            };
        }
    }
}
