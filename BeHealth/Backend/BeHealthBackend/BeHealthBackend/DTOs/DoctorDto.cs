using BeHealthBackend.DataAccess.Entities;

namespace BeHealthBackend.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public Specialist Specialist { get; set; }
        public List<PatientDto> Patients { get; set; }
    }
}
