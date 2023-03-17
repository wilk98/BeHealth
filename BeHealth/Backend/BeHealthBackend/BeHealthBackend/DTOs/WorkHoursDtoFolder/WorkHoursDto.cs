namespace BeHealthBackend.DTOs.WorkHoursDtoFolder
{
    public class WorkHoursDto
    {
        public int Id { get; set; }
        public int DoctorId { get; init; }
        public string Day { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }

    }
}
