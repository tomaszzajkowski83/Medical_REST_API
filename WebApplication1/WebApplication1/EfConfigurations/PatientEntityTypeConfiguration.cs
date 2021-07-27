using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient);
            builder.Property(e => e.IdPatient).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Birthdate).IsRequired();
            builder.HasData(
                new Patient {IdPatient = 1, Birthdate = new DateTime(1978,04,22), FirstName = "Barttosz", LastName = "Kowalski" },
                new Patient { IdPatient = 2, Birthdate = new DateTime(1993, 5, 12), FirstName = "Łukasz", LastName = "Cieślik" },
                new Patient { IdPatient = 3, Birthdate = new DateTime(1965, 1, 7), FirstName = "Marek", LastName = "Zieliński" }
                );
        }
    }
}
