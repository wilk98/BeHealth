using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DTOs.AccountDtoFolder;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BeHealthBackend.DataAccess.Entities.Validators;
public class CreateDoctorDtoValidator : AbstractValidator<CreateDoctorDto>
{
    public CreateDoctorDtoValidator(BeHealthContext dbContext)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.PhoneNumber)
            .Matches(new Regex("\\d{9}"));

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(50)
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Patients.Any(d => d.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is taken.");
                }
            });

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PostalCode)
            .Matches(new Regex("\\d{2}-\\d{3}"));

        RuleFor(x => x.Specialist)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PasswordHash)
            .Matches(new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"));

        RuleFor(x => x.ConfirmPassword).Equal(e => e.PasswordHash);
    }
}
