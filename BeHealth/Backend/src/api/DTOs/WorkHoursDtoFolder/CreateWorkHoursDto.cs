namespace BeHealthBackend.DTOs.WorkHoursDtoFolder
{
    public class CreateWorkHoursDto
    {
        public int DoctorId { get; init; }
        public string Day { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}
