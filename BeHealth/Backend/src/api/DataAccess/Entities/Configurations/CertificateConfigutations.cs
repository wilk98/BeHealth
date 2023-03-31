using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations;

public class CertificateConfigutations : IEntityTypeConfiguration<Certificate>
{
    void IEntityTypeConfiguration<Certificate>.Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasOne(c => c.Doctor)
            .WithMany();
        builder.Property(c => c.Filename)
            .IsRequired()
            .HasMaxLength(100);
    }
}