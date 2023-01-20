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
                City = "Gdańsk",
                PostalCode = "80-680",
                Street = "ul. Nadwiślańska 112",
                Id = new Guid("69d34af1-2911-4721-a9c7-815a3ad63ecd"),
            },
            new Address
            {
                City = "Gdynia",
                PostalCode = "81-515",
                Street = "ul. Kasztanowa 113",
                Id = new Guid("9030a7cf-dcbc-492a-af58-114be534139c"),
            },new Address
            {
                City = "Warszawa",
                PostalCode = "01-401",
                Street = " ul. Górczewska 82",
                Id = new Guid("29d60fbf-2e9d-4cb1-b183-2392378941af"),
            },new Address
            {
                City = "Łódź",
                PostalCode = "91-503",
                Street = "ul. Górczewska 82",
                Id = new Guid("3d4f37e9-4d2e-4a86-9b2f-679fcbd103a9"),
            });
        }
    }
}
