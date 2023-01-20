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

            builder.HasData(new Patient
            {
                Id = new Guid("1ef9d268-e925-483d-b854-6ed17ba81f81"),
                FirstName = "Adelajda",
                LastName = "Zielinska",
                Email = "AdelajdaZielinska@teleworm.us",
                PhoneNumber = "692435107",
                AddressId = new Guid("69d34af1-2911-4721-a9c7-815a3ad63ecd"),
                Pesel = 380923623,
            },
            new Patient
            {
                Id = new Guid("a3fbe5f5-11bf-41f2-9aa0-578720514df3"),
                FirstName = "Witołd",
                LastName = "Kwiatkowski",
                Email = "WitoldKwiatkowski@armyspy.com",
                PhoneNumber = "784251125    ",
                AddressId = new Guid("29d60fbf-2e9d-4cb1-b183-2392378941af"),
                Pesel = 990819957,
            },new Patient
            {
                Id = new Guid("2f9343e6-667c-4f86-9f10-86019aed7c62"),
                FirstName = "Jakub",
                LastName = "Grabowski",
                Email = "JakubGrabowski@rhyta.com",
                PhoneNumber = "531556254",
                AddressId = new Guid("3d4f37e9-4d2e-4a86-9b2f-679fcbd103a9"),
                Pesel = 500501563,
            });
        }
    }
}
