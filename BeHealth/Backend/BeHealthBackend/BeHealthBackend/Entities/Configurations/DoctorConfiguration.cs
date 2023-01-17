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

            builder.HasMany(d => d.Patients)
                .WithMany(p => p.Doctors);

            builder.Property(a => a.PhoneNumber).HasColumnType("varchar(9)");
        }
    }
}
