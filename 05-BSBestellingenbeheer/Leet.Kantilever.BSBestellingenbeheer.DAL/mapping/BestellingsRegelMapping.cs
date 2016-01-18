using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mapping
{
    class BestellingsRegelMapping : EntityTypeConfiguration<BestellingsRegel>
    {
        public BestellingsRegelMapping()
        {
            this.ToTable("Bestellingsregel");
        }
    }
}
