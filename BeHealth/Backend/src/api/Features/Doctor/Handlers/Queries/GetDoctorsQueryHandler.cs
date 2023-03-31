using application.Dtos.DoctorDtoFolder;
using AutoMapper;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.Features.Account.Request.Queries;
using MediatR;

namespace BeHealthBackend.Features.Doctor.Handlers.Queries
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<DoctorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _unitOfWork.DoctorRepository
            .GetAllAsync(includeProperties: "Address");

            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

            return doctorsDto;
        }
    }
}
