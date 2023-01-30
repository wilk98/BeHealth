using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .Property(d => d.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(a => a.PhoneNumber).HasColumnType("varchar(9)");

            builder.HasMany(d => d.Patients)
                .WithMany(p => p.Doctors)
                .UsingEntity<DoctorPatient>(
                    dp => dp.HasOne(p => p.Patient)
                        .WithMany()
                        .HasForeignKey(dp => dp.PatientId)
                        .OnDelete(DeleteBehavior.ClientCascade),
                    dp => dp.HasOne(d => d.Doctor)
                        .WithMany()
                        .HasForeignKey(dp => dp.DoctorId),
                    dp =>
                    {
                        dp.HasKey(x => new { x.PatientId, x.DoctorId });
                    }
                );
            builder.HasData(new Doctor
            {
                Id = 1,
                AddressId = 1,
                FirstName = "Eugeniusz",
                LastName = "Kamiński",
                Email = "EugeniuszKaminski@dayrep.com",
                PhoneNumber = "519439105",
                Specialist = Specialist.Oculist,
            });
        }
    }
}
