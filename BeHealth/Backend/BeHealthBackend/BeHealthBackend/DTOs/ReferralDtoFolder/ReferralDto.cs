namespace BeHealthBackend.DTOs.ReferralDtoFolder
{
    public class ReferralDto
    {
        public int Id { get; set; }
        public string? Patient { get; set; }
        public int? PatientId { get; init; }
        public long Date { get; set; }
        public string? Specialist { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
    }
}
