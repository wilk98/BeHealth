using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.DataAccess.Entities.Configurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasOne(v => v.Patient)
                .WithMany(p => p.Visits)
                .HasForeignKey(v => v.PatientId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(v => v.Doctor)
                .WithMany(p => p.Visits)
                .HasForeignKey(v => v.DoctorId);

            builder.HasData(new Visit
            {
                Id = -1,
                Name = "Konsultacja ortopedyczna + USG",
                DoctorId = new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"),
                PatientId = new Guid("1ef9d268-e925-483d-b854-6ed17ba81f81"),
                VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672570800),
                Duration = 65,
            }, new Visit{
                Id = -2,
                Name = "Konsultacja reumatologiczna",
                DoctorId = new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"),
                PatientId = new Guid("a3fbe5f5-11bf-41f2-9aa0-578720514df3"),
                VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672575000),
                Duration = 60,
            }, new Visit{
                Id = -3,
                Name = "Terapia osoczem bogatym w czynniki wzrostu- PRP",
                DoctorId = new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"),
                PatientId = new Guid("2f9343e6-667c-4f86-9f10-86019aed7c62"),
                VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672579800),
                Duration = 45,
            }, new Visit{
                Id = -4,
                Name = "Terapia Orthokine",
                DoctorId = new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"),
                PatientId = new Guid("1ef9d268-e925-483d-b854-6ed17ba81f81"),
                VisitDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1672662600),
                Duration = 60,
            });
        }
    }
}
