using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(c => c.Clinic)
                .WithOne(a => a.Address)
                .HasForeignKey<Clinic>(c => c.AddressId);

            builder.HasOne(p => p.Doctor)
                .WithOne(a => a.Address)
                .HasForeignKey<Doctor>(p => p.AddressId);

            builder.HasOne(p => p.Patient)
                .WithOne(a => a.Address)
                .HasForeignKey<Patient>(p => p.AddressId);

            builder.Property(a => a.PostalCode).HasColumnType("varchar(6)");

            builder.HasData(new Address
            {
                Id = 1,
                City = "Gdańsk",
                PostalCode = "80-680",
                Street = "ul. Nadwiślańska 112"
            },
            new Address
            {
                Id = 2,
                City = "Gdynia",
                PostalCode = "81-515",
                Street = "ul. Kasztanowa 113"
            },new Address
            {
                Id = 3,
                City = "Warszawa",
                PostalCode = "01-401",
                Street = " ul. Górczewska 82"
            },new Address
            {
                Id= 4,
                City = "Łódź",
                PostalCode = "91-503",
                Street = "ul. Górczewska 82"
            });
        }
    }
}
