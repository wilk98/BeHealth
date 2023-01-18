namespace BeHealthBackend.Entities
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}