using System.Data.Entity.ModelConfiguration;

namespace Leet.Kantilever.PcSWinkelen.DAL.Entities.Mapping
{
    public class WinkelmandMapping : EntityTypeConfiguration<Winkelmand>
    {
        public WinkelmandMapping()
        {
            this.ToTable("Winkelmand")
                .Property(w => w.ClientID).HasMaxLength(100);
        }
    }
}