namespace BeHealthBackend.DTOs
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public long StartDate { get; set; }
        public string? Treatment { get; init; }
        public string? Patient { get; init; }
        public Guid? PatientId { get; init; }
        public int Duration { get; set; }
    }
}
