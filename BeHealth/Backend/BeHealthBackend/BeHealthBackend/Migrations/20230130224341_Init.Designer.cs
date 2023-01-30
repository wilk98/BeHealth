﻿// <auto-generated />
using System;
using BeHealthBackend.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeHealthBackend.Migrations
{
    [DbContext(typeof(BeHealthContext))]
    [Migration("20230130224341_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gdańsk",
                            PostalCode = "80-680",
                            Street = "ul. Nadwiślańska 112"
                        },
                        new
                        {
                            Id = 2,
                            City = "Gdynia",
                            PostalCode = "81-515",
                            Street = "ul. Kasztanowa 113"
                        },
                        new
                        {
                            Id = 3,
                            City = "Warszawa",
                            PostalCode = "01-401",
                            Street = " ul. Górczewska 82"
                        },
                        new
                        {
                            Id = 4,
                            City = "Łódź",
                            PostalCode = "91-503",
                            Street = "ul. Górczewska 82"
                        });
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.ClinicDoctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "ClinicId");

                    b.HasIndex("ClinicId");

                    b.ToTable("ClinicDoctor");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.ClinicPatient", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "ClinicId");

                    b.HasIndex("ClinicId");

                    b.ToTable("ClinicPatient");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<int>("Specialist")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "EugeniuszKaminski@dayrep.com",
                            FirstName = "Eugeniusz",
                            LastName = "Kamiński",
                            PhoneNumber = "519439105",
                            Specialist = 9
                        });
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.DoctorPatient", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pesel")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "AdelajdaZielinska@teleworm.us",
                            FirstName = "Adelajda",
                            LastName = "Zielinska",
                            Pesel = 380923623,
                            PhoneNumber = "692435107"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 3,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "WitoldKwiatkowski@armyspy.com",
                            FirstName = "Witołd",
                            LastName = "Kwiatkowski",
                            Pesel = 990819957,
                            PhoneNumber = "784251125    "
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 4,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "JakubGrabowski@rhyta.com",
                            FirstName = "Jakub",
                            LastName = "Grabowski",
                            Pesel = 500501563,
                            PhoneNumber = "531556254"
                        });
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visit");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            DoctorId = 1,
                            Duration = 65,
                            Name = "Konsultacja ortopedyczna + USG",
                            PatientId = 1,
                            VisitDate = new DateTime(2023, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = -2,
                            DoctorId = 1,
                            Duration = 60,
                            Name = "Konsultacja reumatologiczna",
                            PatientId = 1,
                            VisitDate = new DateTime(2023, 1, 1, 12, 10, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = -3,
                            DoctorId = 1,
                            Duration = 45,
                            Name = "Terapia osoczem bogatym w czynniki wzrostu- PRP",
                            PatientId = 2,
                            VisitDate = new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = -4,
                            DoctorId = 1,
                            Duration = 60,
                            Name = "Terapia Orthokine",
                            PatientId = 3,
                            VisitDate = new DateTime(2023, 1, 2, 12, 30, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Clinic", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Address", "Address")
                        .WithOne("Clinic")
                        .HasForeignKey("BeHealthBackend.DataAccess.Entities.Clinic", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.ClinicDoctor", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeHealthBackend.DataAccess.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.ClinicPatient", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeHealthBackend.DataAccess.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Doctor", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Address", "Address")
                        .WithOne("Doctor")
                        .HasForeignKey("BeHealthBackend.DataAccess.Entities.Doctor", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.DoctorPatient", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeHealthBackend.DataAccess.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Patient", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Address", "Address")
                        .WithOne("Patient")
                        .HasForeignKey("BeHealthBackend.DataAccess.Entities.Patient", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Visit", b =>
                {
                    b.HasOne("BeHealthBackend.DataAccess.Entities.Doctor", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeHealthBackend.DataAccess.Entities.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Address", b =>
                {
                    b.Navigation("Clinic")
                        .IsRequired();

                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Doctor", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("BeHealthBackend.DataAccess.Entities.Patient", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
