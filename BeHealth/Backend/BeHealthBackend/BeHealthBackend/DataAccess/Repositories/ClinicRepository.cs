using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackend.DataAccess.Repositories;

public class ClinicRepository : Repository<Clinic>, IClinicRepository
{
    public ClinicRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Clinics;
    }

    public async Task<List<Clinic>> GetByDoctorIdAsync(int doctorId)
    {
        return await DbSet.Where(c => c.Doctors.Any(d => d.Id == doctorId)).ToListAsync();
    }
}