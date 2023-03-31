namespace BeHealthBackend.DTOs.VisitDtoFolder
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public long StartDate { get; set; }
        public string Treatment { get; init; }
        public string Patient { get; init; }
        public int PatientId { get; init; }
        public int Duration { get; set; }
        public bool? Confirmed { get; set; }
    }
}
