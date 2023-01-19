using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackend.DataAccess.Entities.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .Property(p => p.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(a => a.PhoneNumber).HasColumnType("varchar(9)");
        }
    }
}
