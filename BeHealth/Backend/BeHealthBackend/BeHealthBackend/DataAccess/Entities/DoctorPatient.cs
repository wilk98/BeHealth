namespace BeHealthBackend.DataAccess.Entities
{
    public class DoctorPatient
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
