using BeHealthBackend.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeHealthBackend.DTOs.Patient;
public class CreatePatientDto
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

