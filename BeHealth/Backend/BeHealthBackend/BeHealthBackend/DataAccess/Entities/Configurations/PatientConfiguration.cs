using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackend.DataAccess.Entities.Configurations;
public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasColumnType("varchar(9)");

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Created)
            .HasDefaultValueSql("getdate()");

        builder.Property(p => p.Pesel)
            .HasColumnType("varchar(11)");

        builder.Property(p => p.PasswordHash)
            .IsRequired();

        //builder.HasData(
        //    new Patient
        //    {
        //        Id = 1,
        //        AddressId = 1,
        //        FirstName = "Adelajda",
        //        LastName = "Zielinska",
        //        Email = "AdelajdaZielinska@teleworm.us",
        //        PhoneNumber = "692435107",
        //        Pesel = "12345678901",
        //        PasswordHash = "azxsdcvfrewqthb"
        //    },
        //    new Patient
        //{
        //    Id = 2,
        //    AddressId = 2,
        //    FirstName = "Witołd",
        //    LastName = "Kwiatkowski",
        //    Email = "WitoldKwiatkowski@armyspy.com",
        //    PhoneNumber = "784251125",
        //    Pesel = "12345678901",
        //    PasswordHash = "azxsdcvfrewq12"
        //    }, 
        //    new Patient 
        //{
        //    Id = 3,
        //    AddressId = 3,
        //    FirstName = "Arni",
        //    LastName = "Umbala",
        //    Email = "Wolny23@armyspy.com",
        //    PhoneNumber = "879654239",
        //    Pesel = "12345678901",
        //    PasswordHash = "azxsdcvfrewqfsa"
        //    },
        //    new Patient
        //{
        //    Id = 4,
        //    AddressId = 4,
        //    FirstName = "Jakub",
        //    LastName = "Grabowski",
        //    Email = "JakubGrabowski@rhyta.com",
        //    PhoneNumber = "531556254",
        //    Pesel = "12345678901",
        //    PasswordHash = "azxsdcvfavssw"
        //    });
    }
}