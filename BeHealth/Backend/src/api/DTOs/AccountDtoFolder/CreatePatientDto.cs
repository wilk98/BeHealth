using System.ComponentModel.DataAnnotations;

namespace BeHealthBackend.DTOs.AccountDtoFolder;
public class CreatePatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string Pesel { get; set; }
    public string PasswordHash { get; set; }
    public string ConfirmPassword { get; set; }
}