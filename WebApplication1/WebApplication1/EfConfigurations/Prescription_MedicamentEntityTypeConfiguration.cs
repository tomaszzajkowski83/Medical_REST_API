using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class Prescription_MedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription});
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(e=>e.IdMedicament);

            builder.HasOne(e => e.Prescription)
                    .WithMany(p => p.Medicaments)
                    .HasForeignKey(e => e.IdPrescription);
            builder.HasData(
                new Prescription_Medicament {IdMedicament = 1, IdPrescription = 1, Dose = 10, Details = "Stosować po jedzeniu" },
                new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 3, Details = "3x/dzień" },
                new Prescription_Medicament { IdMedicament = 3, IdPrescription = 2, Dose = 1, Details = "Regularnie i do końca życia" },
                new Prescription_Medicament { IdMedicament = 4, IdPrescription = 1, Dose = 1, Details = "Tylko w nagłych przypadkach" },
                new Prescription_Medicament { IdMedicament = 2, IdPrescription = 3, Dose = 7, Details = "Najpierw 3x dziennie, po tygodniu 1x/dobę" }
                );
        }
    }
}
