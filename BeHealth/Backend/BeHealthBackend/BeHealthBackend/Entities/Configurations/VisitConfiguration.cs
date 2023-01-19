using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeHealthBackend.Entities.Configurations
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
        }
    }
}
