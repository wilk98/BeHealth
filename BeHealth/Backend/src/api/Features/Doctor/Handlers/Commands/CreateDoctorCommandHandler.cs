using application.Dtos.AccountDtoFolder;
using application.Dtos.DoctorDtoFolder;
using AutoMapper;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.Features.Doctor.Request.Commands;
using MediatR;

namespace BeHealthBackend.Features.Doctor.Handlers.Commands
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateDoctorCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<CreateDoctorDto, >;
            var hashedPassword = _passwordHasher.HashPassword(doctor, dto.PasswordHash);
            doctor.PasswordHash = hashedPassword;

            await _unitOfWork.DoctorRepository.AddAsync(doctor);
            await _unitOfWork.SaveAsync();

            return (doctor.Id, _mapper.Map<CreateDoctorDto>(doctor));
        }
    }
}
