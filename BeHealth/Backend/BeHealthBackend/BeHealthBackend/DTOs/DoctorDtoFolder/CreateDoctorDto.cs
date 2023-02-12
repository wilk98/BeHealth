using System.ComponentModel.DataAnnotations;

namespace BeHealthBackend.DTOs.DoctorDtoFolder;
public class CreateDoctorDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? Specialist { get; set; }
    public string? PasswordHash { get; set; }
    public string ConfirmPassword { get; set; }
}
