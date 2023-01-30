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
                Id = 1,
                AddressId = 2,
                FirstName = "Adelajda",
                LastName = "Zielinska",
                Email = "AdelajdaZielinska@teleworm.us",
                PhoneNumber = "692435107",
                Pesel = 380923623,
            },
            new Patient
            {
                Id = 2,
                AddressId = 3,
                FirstName = "Witołd",
                LastName = "Kwiatkowski",
                Email = "WitoldKwiatkowski@armyspy.com",
                PhoneNumber = "784251125    ",
                Pesel = 990819957,
            },new Patient
            {
                Id = 3,
                AddressId = 4,
                FirstName = "Jakub",
                LastName = "Grabowski",
                Email = "JakubGrabowski@rhyta.com",
                PhoneNumber = "531556254",
                Pesel = 500501563,
            });
        }
    }
}
