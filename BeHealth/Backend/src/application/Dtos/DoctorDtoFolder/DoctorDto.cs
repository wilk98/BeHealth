using System.ComponentModel.DataAnnotations;
using core;

namespace application.Dtos.DoctorDtoFolder;
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
    public string Specialist { get; set; }
}