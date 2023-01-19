namespace BeHealthBackend.DataAccess.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}