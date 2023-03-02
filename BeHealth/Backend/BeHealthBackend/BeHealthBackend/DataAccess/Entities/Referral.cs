namespace BeHealthBackend.DataAccess.Entities
{
    public class Referral
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public DateTime Created { get; set; }
        public string? Specialist { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
    }
}
