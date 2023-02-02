using System.ComponentModel.DataAnnotations;

namespace BeHealthBackend.DTOs.DoctorDtoFolder;
public class UpdateDoctorDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}

