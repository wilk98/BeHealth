using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations;
public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientId);

        builder.HasOne(v => v.Doctor)
            .WithMany(d => d.Visits)
            .HasForeignKey(v => v.DoctorId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new Visit
        {
            Id = 1,
            DoctorId = 1,
            PatientId = 1,
            Name = "Konsultacja ortopedyczna + USG",
            VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672570800),
            Duration = 65,
        }, 
            new Visit
        {
            Id = 2,
            DoctorId = 1,
            PatientId = 1,
            Name = "Konsultacja reumatologiczna",
            VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672575000),
            Duration = 60,
        }, 
            new Visit
        {
            Id = 3,
            DoctorId = 1,
            PatientId = 2,
            Name = "Terapia osoczem bogatym w czynniki wzrostu- PRP",
            VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672579800),
            Duration = 45,
        }, 
            new Visit
        {
            Id = 4,
            DoctorId = 1,
            PatientId = 3,
            Name = "Terapia Orthokine",
            VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672662600),
            Duration = 60,
        });
    }
}