using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.Entities.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasMany(c => c.Patients)
                .WithMany(p => p.Clinics);

            builder.HasMany(c => c.Doctors)
                .WithMany(d => d.Clinics);
        }
    }
}
