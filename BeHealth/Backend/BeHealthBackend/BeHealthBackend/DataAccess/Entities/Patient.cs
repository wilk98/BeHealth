namespace BeHealthBackend.DataAccess.Entities;
public class Patient : Person
{
    public string Pesel { get; set; }
    public virtual List<Clinic> Clinics { get; set; } = new List<Clinic>();
    public virtual List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public int RoleId { get; set; } = 2;
    public virtual Role Role { get; set; }
}