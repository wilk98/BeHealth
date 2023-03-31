namespace core
{
    public class ClinicDoctor
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
