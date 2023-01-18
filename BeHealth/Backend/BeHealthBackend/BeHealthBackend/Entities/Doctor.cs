namespace BeHealthBackend.Entities
{
    public class Doctor : Person
    {
        public Guid Id { get; set; }
        public Specialist Specialist { get; set; }
        public virtual List<Clinic> Clinics { get; set; } = new List<Clinic>();
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
        public virtual List<Visit> Visits { get; set; } = new List<Visit>();
    }
}
