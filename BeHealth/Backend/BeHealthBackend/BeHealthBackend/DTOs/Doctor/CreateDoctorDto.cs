using System.ComponentModel.DataAnnotations;
using BeHealthBackend.DataAccess.Entities;

namespace BeHealthBackend.DTOs.Doctor
{
    public class CreateDoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public Specialist Specialist { get; set; }
    }
}
