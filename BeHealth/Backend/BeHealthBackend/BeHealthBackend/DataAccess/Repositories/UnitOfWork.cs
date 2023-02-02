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

        public IPersonRepository PersonRepository { get; }

        public IVisitRepository VisitRepository { get; }

        public UnitOfWork(BeHealthContext context)
        {
            _context = context;
            AddressRepository = new AddressRepository(_context);
            ClinicRepository = new ClinicRepository(_context);
            DoctorRepository = new DoctorRepository(_context);
            PatientRepository = new PatientRepository(_context);
            PersonRepository = new PersonRepository(_context);
            VisitRepository = new VisitRepository(_context);
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
