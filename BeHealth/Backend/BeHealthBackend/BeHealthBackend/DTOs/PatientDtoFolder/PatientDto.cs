using System.ComponentModel.DataAnnotations;

namespace BeHealthBackend.DTOs.PatientDtoFolder
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Pesel { get; set; }
    }
}
