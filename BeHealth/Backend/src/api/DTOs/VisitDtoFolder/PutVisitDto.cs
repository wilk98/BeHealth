namespace BeHealthBackend.DTOs.VisitDtoFolder
{
    public class PutVisitDto
    {
        public string Name { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
        public bool? Confirmed { get; set; }
    }
}
