using AutoMapper;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.ClinicDtoFolder;
using BeHealthBackend.DTOs.PatientDtoFolder;
using BeHealthBackend.DTOs.VisitDtoFolder;
using BeHealthBackend.DTOs.WorkHoursDtoFolder;
using System.ComponentModel;

namespace BeHealthBackend.Services.WorkHoursServices
{
    public class WorkHoursService : IWorkHoursService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkHoursService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(int, CreateWorkHoursDto)> CreateAsync(CreateWorkHoursDto workHoursDto)
        {
            var workHours = new WorkHours
            {
                DoctorId = workHoursDto.DoctorId,
                Day = workHoursDto.Day,
                StartHour = workHoursDto.StartHour,
                EndHour = workHoursDto.EndHour
            };

            await _unitOfWork.WorkHoursRepository.AddAsync(workHours);
            await _unitOfWork.SaveAsync();

            var createdWorkHoursDto = new CreateWorkHoursDto
            {
                DoctorId = workHours.DoctorId,
                Day = workHours.Day,
                StartHour = workHours.StartHour,
                EndHour = workHours.EndHour
            };

            return (workHours.Id, createdWorkHoursDto);
        }

        public async Task<IEnumerable<WorkHoursDto>> GetWorkHoursByDoctorIdAsync(int id)
        {
            var workHours = await _unitOfWork.WorkHoursRepository.GetAllAsync(
                filter: h => h.DoctorId.Equals(id),
                orderBy: hours => hours.OrderBy(h => h.Day));

            var workHoursDto = workHours.Select(h => new WorkHoursDto
            {
                Id = h.Id,
                DoctorId = h.DoctorId,
                Day = h.Day,
                StartHour = h.StartHour,
                EndHour = h.EndHour,
            }
        );


            return workHoursDto;

        }
    }
}
