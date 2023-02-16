using System.ComponentModel.DataAnnotations;

namespace BeHealthBackend.DTOs.PatientDtoFolder;
public class CreatePatientDto
{
    [Required]
    [MaxLength(20)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(30)]
    public string? LastName { get; set; }
    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; set; }
    [Required]
    [MaxLength(30)]
    public string? City { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Street { get; set; }
    [Required]
    [StringLength(6)]
    public string? PostalCode { get; set; }
    [StringLength(11)]
    public string Pesel { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
}