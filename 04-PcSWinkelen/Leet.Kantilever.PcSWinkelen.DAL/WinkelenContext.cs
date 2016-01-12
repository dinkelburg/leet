using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using Leet.Kantilever.PcSWinkelen.DAL.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL
{
    public class WinkelenContext : DbContext
    {
        public WinkelenContext() : base() { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Winkelmand> Winkelmanden { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new WinkelmandMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
