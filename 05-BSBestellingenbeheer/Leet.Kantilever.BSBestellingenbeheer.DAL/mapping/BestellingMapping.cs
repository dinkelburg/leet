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
            ToTable("Bestelling");
            HasKey(x => x.ID);
            Property(x => x.Klantnummer)
                .HasMaxLength(100);
            Property(property => property.Bestelnummer).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
