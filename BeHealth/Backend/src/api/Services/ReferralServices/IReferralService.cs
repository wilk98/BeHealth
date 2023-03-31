using application.Dtos.ReferralDtoFolder;

namespace BeHealthBackend.Services.ReferralService
{
    public interface IReferralService
    {
        Task<IEnumerable<ReferralDto>> GetIdAsync(int id);
    }
}
