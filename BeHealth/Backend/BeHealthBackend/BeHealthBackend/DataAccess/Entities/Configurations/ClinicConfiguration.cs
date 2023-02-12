using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations
{
    public class ClinicPatientConfiguration : IEntityTypeConfiguration<ClinicPatient>
    {
        public void Configure(EntityTypeBuilder<ClinicPatient> builder)
        {
            //builder.HasData(
            //    new ClinicPatient
            //{
            //    ClinicId = 1,
            //    PatientId = 1
            //}, 
            //    new ClinicPatient
            //{
            //    ClinicId = 1,
            //    PatientId = 2
            //},
            //    new ClinicPatient
            //{
            //    ClinicId = 1,
            //    PatientId = 3
            //},
            //    new ClinicPatient
            //{
            //    ClinicId = 2,
            //    PatientId = 3
            //},
            //    new ClinicPatient
            //{
            //    ClinicId = 2,
            //    PatientId = 4
            //});
        }
    }

    public class ClinicDoctorConfiguration : IEntityTypeConfiguration<ClinicDoctor>
    {
        public void Configure(EntityTypeBuilder<ClinicDoctor> builder)
        {
            //builder.HasData(
            //    new ClinicDoctor
            //{
            //    ClinicId = 1,
            //    DoctorId = 1
            //}, 
            //    new ClinicDoctor
            //{
            //    ClinicId = 1,
            //    DoctorId = 2
            //},
            //new ClinicDoctor
            //{
            //    ClinicId = 2,
            //    DoctorId = 2
            //});
        }
    }

    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasMany(c => c.Patients)
                .WithMany(p => p.Clinics)
                .UsingEntity<ClinicPatient>(
                    cp => cp.HasOne(p => p.Patient)
                        .WithMany()
                        .HasForeignKey(cp => cp.PatientId),
                    cp => cp.HasOne(c => c.Clinic)
                        .WithMany()
                        .HasForeignKey(cp => cp.ClinicId)
                        .OnDelete(DeleteBehavior.ClientCascade),
                    cp =>
                    {
                        cp.HasKey(x => new { x.PatientId, x.ClinicId });
                    }
                );

            builder.HasMany(c => c.Doctors)
                .WithMany(d => d.Clinics)
                .UsingEntity<ClinicDoctor>(
                    cd => cd.HasOne(d => d.Doctor)
                        .WithMany()
                        .HasForeignKey(cd => cd.DoctorId),
                    cd => cd.HasOne(c => c.Clinic)
                        .WithMany()
                        .HasForeignKey(cd => cd.ClinicId)
                        .OnDelete(DeleteBehavior.ClientCascade),
                    cd =>
                    {
                        cd.HasKey(x => new { x.DoctorId, x.ClinicId });
                    }
                );

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Description)
                .HasMaxLength(500);

            //builder.HasData(
            //    new Clinic
            // {
            //     Id = 1,
            //     Name = "Klinika Uśmiechu",
            //     Description = "Zapraszamy",
            //     AddressId = 5
            // }, 
            //    new Clinic
            //{
            //    Id = 2,
            //    Name = "Klinika Zdrowia",
            //    Description = "Lecz się u nas!",
            //    AddressId = 2
            //});
        }
    }
}
