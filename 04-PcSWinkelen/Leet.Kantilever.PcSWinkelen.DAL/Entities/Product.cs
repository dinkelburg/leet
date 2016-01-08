using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string AfbeeldingURL { get; set; }
        public string Beschrijving { get; set; }
        public string LeverancierNaam { get; set; }
        public string LeveranciersProductId { get; set; }
        public DateTime LeverbaarTot { get; set; }
        public DateTime LeverbaarVanaf { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public string ClientId { get; set; }
    }
}
