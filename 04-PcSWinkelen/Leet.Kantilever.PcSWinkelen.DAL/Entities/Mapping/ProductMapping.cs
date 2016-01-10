using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL.Entities.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            this.ToTable("Product");

            this.Property(p => p.AfbeeldingURL).HasMaxLength(100);
            this.Property(p => p.Beschrijving).HasMaxLength(1000);
            this.Property(p => p.LeverancierNaam).HasMaxLength(100);
            this.Property(p => p.LeveranciersProductId).HasMaxLength(25);
            this.Property(p => p.Naam).HasMaxLength(100);

        }
    }
}
