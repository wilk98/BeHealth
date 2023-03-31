namespace BeHealthBackend.DataAccess.Entities
{
    public class WorkHours
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public string Day { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}
