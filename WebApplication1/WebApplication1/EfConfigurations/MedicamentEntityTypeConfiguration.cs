using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class MedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament);
            builder.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Medicament {IdMedicament = 1, Description = "Zwalcza bóle i nic więcej", Name = "APAP", Type = "Przeciwbólowy"},
                new Medicament { IdMedicament = 2, Description = "Daje niezłe jady", Name = "MORFINA", Type = "Opioidowy" },
                new Medicament { IdMedicament = 3, Description = "Mocny przeciwbólowy i przeciwzapalny", Name = "DIPHROPOS", Type = "Steryd" },
                new Medicament { IdMedicament = 4, Description = "Nitro dla facetów", Name = "VIAGRA", Type = "Wzmacniający" }
                );
        }
    }
}
