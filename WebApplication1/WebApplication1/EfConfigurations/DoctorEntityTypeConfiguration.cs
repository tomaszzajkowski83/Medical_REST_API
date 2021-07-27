using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor);
            builder.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Doctor {IdDoctor = 1, Email = "doktorek1@gmail.com", FirstName = "Janusz", LastName = "Ziobro"},
                new Doctor { IdDoctor = 2, Email = "kosiorek@gmail.com", FirstName = "Krzysztof", LastName = "Białek"},
                new Doctor { IdDoctor = 3, Email = "bigosek@gmail.com", FirstName = "Leon", LastName = "Spater" }
                );
        }
    }
}
