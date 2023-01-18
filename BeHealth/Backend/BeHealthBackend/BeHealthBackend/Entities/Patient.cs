namespace BeHealthBackend.Entities
{
    public class Patient : Person
    {
        public Guid Id { get; set; }
        public int Pesel { get; set; }
        public virtual List<Clinic> Clinics { get; set; } = new List<Clinic>();
        public virtual List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual List<Visit> Visits { get; set; } = new List<Visit>();
    }
}
