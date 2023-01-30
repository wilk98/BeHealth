namespace BeHealthBackend.DataAccess.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
    }
}
