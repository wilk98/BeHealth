using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs;
using BeHealthBackend.DTOs.Visit;

namespace BeHealthBackend.Configurations.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dto => dto.City, d => d.MapFrom(c => c.Address.City))
                .ForMember(dto => dto.Street, d => d.MapFrom(c => c.Address.Street))
                .ForMember(dto => dto.PostalCode, d => d.MapFrom(c => c.Address.PostalCode));

            CreateMap<Patient, PatientDto>()
                .ForMember(dto => dto.City, p => p.MapFrom(c => c.Address.City))
                .ForMember(dto => dto.Street, p => p.MapFrom(c => c.Address.Street))
                .ForMember(dto => dto.PostalCode, p => p.MapFrom(c => c.Address.PostalCode));

            CreateMap<CreateDoctorDto, Doctor>()
                .ForMember(d => d.Address,
                    c => c.MapFrom(dto => new Address()
                        { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode })).ReverseMap(); ;

            CreateMap<UpdateDoctorDto, Doctor>();

            CreateMap<CreateVisitDto, Visit>();

            CreateMap<PutVisitDto, Visit>();
        }
    }
}