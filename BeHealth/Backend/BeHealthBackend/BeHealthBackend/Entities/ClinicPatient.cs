namespace BeHealthBackend.Entities
{
    public class ClinicPatient
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
