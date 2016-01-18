using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using Leet.Kantilever.BSBestellingenbeheer.DAL.mapping;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BestellingMapping());
            modelBuilder.Configurations.Add(new BestellingsRegelMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
