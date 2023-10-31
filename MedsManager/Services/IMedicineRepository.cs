using MedsManager.Models;

namespace MedsManager.Services
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllMedsAsync();
        Task<Medicine> GetByIdAsync(Guid id);
    }
}