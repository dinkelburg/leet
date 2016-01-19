using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mapping
{
    class BestellingMapping : EntityTypeConfiguration<Bestelling>
    {
        public BestellingMapping()
        {
            this.ToTable("Bestelling");

            this.HasKey(x => x.ID);

            this.Property(x => x.Klantnummer)
                .HasMaxLength(100);

            this.Property(x => x.Status)
                .IsConcurrencyToken();
        }
    }
}
