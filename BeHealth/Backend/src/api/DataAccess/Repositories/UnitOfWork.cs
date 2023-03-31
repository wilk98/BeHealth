using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;

namespace BeHealthBackend.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BeHealthContext _context;

        public IAddressRepository AddressRepository { get; }

        public IClinicRepository ClinicRepository { get; }

        public IDoctorRepository DoctorRepository { get; }

        public IPatientRepository PatientRepository { get; }

        public IVisitRepository VisitRepository { get; }

        public IReferralRepository ReferralRepository { get; }
        public IRecipeRepository RecipeRepository { get; }
        public IWorkHoursRepository WorkHoursRepository { get; }

        public UnitOfWork(BeHealthContext context)
        {
            _context = context;
            AddressRepository = new AddressRepository(_context);
            ClinicRepository = new ClinicRepository(_context);
            DoctorRepository = new DoctorRepository(_context);
            PatientRepository = new PatientRepository(_context);
            VisitRepository = new VisitRepository(_context);
            ReferralRepository = new ReferralRepository(_context);
            RecipeRepository = new RecipeRepository(_context);
            WorkHoursRepository = new WorkHoursRepository(_context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
