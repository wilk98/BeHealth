namespace BeHealthBackend.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int DoctorsId { get; set; }
        public virtual List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public int PatientId { get; set; }
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}