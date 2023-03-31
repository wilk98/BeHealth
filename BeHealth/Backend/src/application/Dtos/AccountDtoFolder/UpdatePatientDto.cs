using System.ComponentModel.DataAnnotations;

namespace application.Dtos.AccountDtoFolder;
public class UpdatePatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}