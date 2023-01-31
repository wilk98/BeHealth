namespace BeHealthBackend.DTOs.Visit
{
    public class CreateVisitDto
    {
        public string Name { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
    }
}
