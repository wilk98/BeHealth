using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.Entities.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasMany(c => c.Patients)
                .WithMany(p => p.Clinics)
                .UsingEntity<ClinicPatient>(
                    cp => cp.HasOne(p => p.Patient)
                        .WithMany()
                        .HasForeignKey(cp => cp.PatientId)
                        .OnDelete(DeleteBehavior.ClientCascade),
                    cp => cp.HasOne(c => c.Clinic)
                        .WithMany()
                        .HasForeignKey(cp => cp.ClinicId),
                    cp =>
                    {
                        cp.HasKey(x => new {x.PatientId, x.ClinicId });
                    }
                );

            builder.HasMany(c => c.Doctors)
                .WithMany(d => d.Clinics)
                .UsingEntity<ClinicDoctor>(
                    cd => cd.HasOne(d => d.Doctor)
                        .WithMany()
                        .HasForeignKey(cd => cd.DoctorId)
                        .OnDelete(DeleteBehavior.ClientCascade),
            cd => cd.HasOne(c => c.Clinic)
                        .WithMany()
                        .HasForeignKey(cd => cd.ClinicId),
                    cd =>
                    {
                        cd.HasKey(x => new { x.DoctorId, x.ClinicId });
                    }
                );
        }
    }
}
