using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs.AccountDtoFolder;
using BeHealthBackend.DTOs.ClinicDtoFolder;
using BeHealthBackend.DTOs.DoctorDtoFolder;
using BeHealthBackend.DTOs.PatientDtoFolder;
using BeHealthBackend.DTOs.VisitDtoFolder;

namespace BeHealthBackend.Configurations.Mapper;
public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Doctor, DoctorDto>()
            .ForMember(dto => dto.City, d => d.MapFrom(a => a.Address.City))
            .ForMember(dto => dto.Street, d => d.MapFrom(a => a.Address.Street))
            .ForMember(dto => dto.PostalCode, d => d.MapFrom(a => a.Address.PostalCode));

        CreateMap<CreateDoctorDto, Doctor>()
            .ForMember(d => d.Address,
                c => c.MapFrom(dto => new Address()
                    { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode })).ReverseMap(); ;

        CreateMap<UpdateDoctorDto, Doctor>();

        CreateMap<Patient, PatientDto>()
            .ForMember(dto => dto.City, p => p.MapFrom(a => a.Address.City))
            .ForMember(dto => dto.Street, p => p.MapFrom(a => a.Address.Street))
            .ForMember(dto => dto.PostalCode, p => p.MapFrom(a => a.Address.PostalCode));

        CreateMap<CreatePatientDto, Patient>()
            .ForMember(d => d.Address,
                c => c.MapFrom(dto => new Address()
                    { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode })).ReverseMap(); ;

        CreateMap<UpdatePatientDto, Patient>();

        CreateMap<CreateVisitDto, Visit>();

        CreateMap<PutVisitDto, Visit>();

        CreateMap<Clinic, ClinicDto>()
            .ForMember(dto => dto.City, c => c.MapFrom(a => a.Address.City))
            .ForMember(dto => dto.Street, c => c.MapFrom(a => a.Address.Street))
            .ForMember(dto => dto.PostalCode, c => c.MapFrom(a => a.Address.PostalCode));

        CreateMap<UpdateClinicDto, Clinic>();

        CreateMap<CreateClinicDto, Clinic>();

        CreateMap<Clinic, ClinicDoctorDto> ()
            .ForMember(dto => dto.Name, c => 
                c.MapFrom(d => d.Doctors.Select(dn => $"{dn.FirstName} {dn.LastName}").FirstOrDefault()));
    }
}