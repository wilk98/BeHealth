namespace BeHealthBackend.DTOs
{
    public class VisitDTO
    {
        public long StartDate { get; set; }
        public string? Treatment { get; init; }
        public string? Patient { get; init; }
        public int Duration { get; set; }
    }
}
