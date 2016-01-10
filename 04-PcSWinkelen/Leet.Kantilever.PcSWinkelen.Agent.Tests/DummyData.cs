using Kantilever.BsCatalogusbeheer.Messages.V1;
using Kantilever.BsCatalogusbeheer.Product.V1;
using System;

namespace Leet.Kantilever.PcSWinkelen.Agent.Tests
{
    /// <summary>
    /// This class provides dummy data for test purposes
    /// </summary>
    public class DummyData
    {

        /// <summary>
        /// Dummy data for MsgFindProductByIdResult 
        /// </summary>
        /// <returns>Dummy MsgFindProductByIdResult</returns>
        public static MsgFindProductByIdResult GetMsgFindProductByIdResult()
        {
            return new MsgFindProductByIdResult
            {
                Product = GetProduct(),
                Succes = true,
            };
        }

        /// <summary>
        /// Dummy data for Product 
        /// </summary>
        /// <returns>Dummy Product</returns>
        public static Product GetProduct()
        {
            return new Product
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
                
            };
        }
    }
}