﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "doktorek1@gmail.com",
                            FirstName = "Janusz",
                            LastName = "Ziobro"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "kosiorek@gmail.com",
                            FirstName = "Krzysztof",
                            LastName = "Białek"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "bigosek@gmail.com",
                            FirstName = "Leon",
                            LastName = "Spater"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Zwalcza bóle i nic więcej",
                            Name = "APAP",
                            Type = "Przeciwbólowy"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Daje niezłe jady",
                            Name = "MORFINA",
                            Type = "Opioidowy"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Mocny przeciwbólowy i przeciwzapalny",
                            Name = "DIPHROPOS",
                            Type = "Steryd"
                        },
                        new
                        {
                            IdMedicament = 4,
                            Description = "Nitro dla facetów",
                            Name = "VIAGRA",
                            Type = "Wzmacniający"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(1978, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Barttosz",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1993, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Łukasz",
                            LastName = "Cieślik"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(1965, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marek",
                            LastName = "Zieliński"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.Property<int>("IdPerscription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPerscription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPerscription = 1,
                            Date = new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPerscription = 2,
                            Date = new DateTime(2021, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPerscription = 3,
                            Date = new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 3,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("PrescriptionsWithMedicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "Stosować po jedzeniu",
                            Dose = 10
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 1,
                            Details = "3x/dzień",
                            Dose = 3
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 2,
                            Details = "Regularnie i do końca życia",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 4,
                            IdPrescription = 1,
                            Details = "Tylko w nagłych przypadkach",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 3,
                            Details = "Najpierw 3x dziennie, po tygodniu 1x/dobę",
                            Dose = 7
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.HasOne("WebApplication1.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("WebApplication1.Models.Medicament", "Medicament")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Prescription", "Prescription")
                        .WithMany("Medicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("WebApplication1.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Medicament", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.Navigation("Medicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
