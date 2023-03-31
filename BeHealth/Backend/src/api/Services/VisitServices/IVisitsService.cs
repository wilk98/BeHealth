﻿using BeHealthBackend.DTOs.VisitDtoFolder;
using BeHealthBackend.DTOs.WorkHoursDtoFolder;
using core;

namespace BeHealthBackend.Services.VisitServices;

public interface IVisitsService
{
    Task<bool> DeclineVisit(int visitId);
    Task<bool> AcceptVisit(int visitId);
    Task<IEnumerable<VisitDTO>> GetVisitsByDoctorIdAsync(int id);
    Task<IEnumerable<VisitUserDTO>> GetVisitsByUserIdAsync(int id);
    Task<(int, CreateVisitDto)> CreateAsync(CreateVisitDto visitDto);

    Task<Visit?> PutVisit(int id, PutVisitDto visitDto);
    Task DeleteVisit(int id);
    Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth(int doctorId, DateOnly date);
}
