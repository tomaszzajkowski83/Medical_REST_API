using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPerscription);
            builder.Property(e => e.IdPerscription).ValueGeneratedOnAdd();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(e => e.IdPatient);

            builder.HasOne(e => e.Doctor)
                    .WithMany(d => d.Prescriptions)
                    .HasForeignKey(e => e.IdDoctor);
            builder.HasData(
                new Prescription {IdPerscription = 1, Date = new DateTime(2021,6,10), IdDoctor = 1, IdPatient = 2, DueDate = new DateTime(2021,6,21) },
                new Prescription { IdPerscription = 2, Date = new DateTime(2021, 3, 26), IdDoctor = 2, IdPatient = 1, DueDate = new DateTime(2021, 4, 2) },
                new Prescription { IdPerscription = 3, Date = new DateTime(2021, 5, 11), IdDoctor = 3, IdPatient = 2, DueDate = new DateTime(2021, 6, 1) }
                );
        }
    }
}
