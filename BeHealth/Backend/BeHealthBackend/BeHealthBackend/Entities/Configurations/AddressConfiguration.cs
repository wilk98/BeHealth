using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.Entities.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(p => p.Person)
                .WithOne(a => a.Address)
                .HasForeignKey<Person>(p => p.AddressId);

            builder.HasOne(c => c.Clinic)
                .WithOne(a => a.Address)
                .HasForeignKey<Clinic>(c => c.AddressId);
        }
    }
}
