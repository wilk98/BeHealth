using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.Entities.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .Property(d => d.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(a => a.PhoneNumber).HasColumnType("varchar(9)");

            builder.HasMany(d => d.Patients)
                .WithMany(p => p.Doctors)
                .UsingEntity<DoctorPatient>(
                    dp => dp.HasOne(p => p.Patient)
                        .WithMany()
                        .HasForeignKey(dp => dp.PatientId)
                        .OnDelete(DeleteBehavior.ClientCascade),
                    dp => dp.HasOne(d => d.Doctor)
                        .WithMany()
                        .HasForeignKey(dp => dp.DoctorId),
                    dp =>
                    {
                        dp.HasKey(x => new { x.PatientId, x.DoctorId });
                    }
                );
        }
    }
}
