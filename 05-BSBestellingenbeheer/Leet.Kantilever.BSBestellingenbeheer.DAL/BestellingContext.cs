using Leet.Kantilever.BSBestellingenbeheer.DAL.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL
{
    public class BestellingContext : DbContext
    {
        public BestellingContext() : base("name=BestellingContext") { }

        public DbSet<Bestelling> Bestellingen { get; set; }



    }
}
