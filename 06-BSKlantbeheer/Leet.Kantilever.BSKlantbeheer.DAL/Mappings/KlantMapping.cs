using System.Data.Entity.ModelConfiguration;
using Leet.Kantilever.BSKlantbeheer.DAL.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leet.Kantilever.BSKlantbeheer.DAL
{
    class KlantMapping : EntityTypeConfiguration<Klant>
    {
        public KlantMapping()
        {
            this.ToTable("Klant");
            this.HasKey(x => x.ID);
            this.Property(x => x.Klantnummer)
                    .HasMaxLength(100)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Klantnummer") { IsUnique = true }));
            this.Property(x => x.Gebruikersnaam)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute("IX_Gebruikersnaam") { IsUnique = true }));
            this.Property(x => x.Voornaam)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(x => x.Tussenvoegsel)
                .HasMaxLength(100);
            this.Property(x => x.Achternaam)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(x => x.Adresregel1)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(x => x.Adresregel2)
                .HasMaxLength(100);
            this.Property(x => x.Postcode)
                .IsRequired()
                .HasMaxLength(7);
            this.Property(x => x.Woonplaats)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(x => x.Telefoonnummer)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(x => x.Email)
                .HasMaxLength(100);
        }
    }
}