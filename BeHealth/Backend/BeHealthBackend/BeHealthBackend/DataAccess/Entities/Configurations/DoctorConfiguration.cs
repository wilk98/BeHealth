using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations;
public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
{
    public void Configure(EntityTypeBuilder<DoctorPatient> builder)
    {
        builder.HasData(
            new DoctorPatient
        {
            DoctorId = 2,
            PatientId = 4
        });
    }
}
public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasMany(d => d.Patients)
            .WithMany(p => p.Doctors)
            .UsingEntity<DoctorPatient>(
                dp => dp.HasOne(p => p.Patient)
                    .WithMany()
                    .HasForeignKey(dp => dp.PatientId),
        dp => dp.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(dp => dp.DoctorId)
                    .OnDelete(DeleteBehavior.ClientCascade),
        dp =>
                {
                    dp.HasKey(x => new { x.PatientId, x.DoctorId });
                }
            );

        builder.Property(d => d.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(d => d.LastName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(d => d.PhoneNumber)
            .IsRequired()
            .HasColumnType("varchar(9)");

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Created)
            .HasDefaultValueSql("getdate()");

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.Property(d => d.Education)
            .HasMaxLength(500);

        builder.Property(d => d.Services)
            .HasMaxLength(500);

        builder.HasData(
            new Doctor
        {
            Id = 1,
            AddressId = 1,
            FirstName = "Eugeniusz",
            LastName = "Kamiński",
            Email = "EugeniuszKaminski@dayrep.com",
            PhoneNumber = "519439105",
            Specialist = "Oculist"
        },
            new Doctor
        {
            Id = 2,
            AddressId = 2,
            FirstName = "Sam",
            LastName = "Kaczyński",
            Email = "SamKaczyński@dayrep.com",
            PhoneNumber = "123432567",
            Specialist = "Cardiologist"
        });
    }
}