using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasOne(p => p.Doctor)
            .WithOne(a => a.Role)
            .HasForeignKey<Doctor>(p => p.AddressId);

        builder.HasOne(p => p.Patient)
            .WithOne(a => a.Role)
            .HasForeignKey<Patient>(p => p.AddressId);

        builder.HasData(
            new Role
        {
            Id = 0,
            Name = "Admin"
        },
            new Role
        {
            Id = 1,
            Name = "Doctor"
        },
            new Role
        {
            Id = 2,
            Name = "Patient"
        });
    }
}