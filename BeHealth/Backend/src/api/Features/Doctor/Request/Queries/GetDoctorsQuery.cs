using core;
using MediatR;
using application.Dtos.DoctorDtoFolder;

namespace BeHealthBackend.Features.Account.Request.Queries;

public class GetDoctorsQuery : IRequest<IEnumerable<DoctorDto>>
{
}
