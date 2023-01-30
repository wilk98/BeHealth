namespace BeHealthBackend.DataAccess.Entities
{
    public class ClinicPatient
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
