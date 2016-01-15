using Leet.Kantilever.BSKlantbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSKlantbeheer.DAL
{
    public class KlantenContext : DbContext
    {
        public KlantenContext() : base("name=KlantenContext") { }

        public DbSet<Klant> Klanten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Klant>(new KlantMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
