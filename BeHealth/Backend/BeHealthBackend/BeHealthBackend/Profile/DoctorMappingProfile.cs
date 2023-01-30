﻿using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs;

namespace BeHealthBackend.Profile
{
    public class DoctorMappingProfile : AutoMapper.Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dto => dto.City, d => d.MapFrom(c => c.Address.City))
                .ForMember(dto => dto.Street, d => d.MapFrom(c => c.Address.Street))
                .ForMember(dto => dto.PostalCode, d => d.MapFrom(c => c.Address.PostalCode));

            CreateMap<Patient, PatientDto>()
                .ForMember(dto => dto.City, p => p.MapFrom(c => c.Address.City))
                .ForMember(dto => dto.Street, p => p.MapFrom(c => c.Address.Street))
                .ForMember(dto => dto.PostalCode, p => p.MapFrom(c => c.Address.PostalCode));
        }
    }
}