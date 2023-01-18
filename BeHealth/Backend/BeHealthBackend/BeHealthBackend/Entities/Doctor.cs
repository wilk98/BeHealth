namespace BeHealthBackend.Entities
{
    public class Doctor : Person
    {
        public Specialist Specialist { get; set; }
        public virtual List<Clinic> Clinics { get; set; } = new List<Clinic>();
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
