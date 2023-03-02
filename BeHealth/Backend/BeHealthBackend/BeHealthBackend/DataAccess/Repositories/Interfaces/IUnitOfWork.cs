namespace BeHealthBackend.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAddressRepository AddressRepository { get; }
    IClinicRepository ClinicRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    IPatientRepository PatientRepository { get; }
    IVisitRepository VisitRepository { get; }
    IReferralRepository ReferralRepository { get; }
    IRecipeRepository RecipeRepository { get; }

    Task SaveAsync();
}
