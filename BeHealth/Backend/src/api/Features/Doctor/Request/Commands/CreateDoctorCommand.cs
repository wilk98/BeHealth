using application.Dtos.AccountDtoFolder;
using application.Dtos.DoctorDtoFolder;
using MediatR;

namespace BeHealthBackend.Features.Doctor.Request.Commands
{
    public record CreateDoctorCommand(CreateDoctorDto DoctorDto) : IRequest<DoctorDto>
    {
    }
}
