using Domain.Entities;

namespace Application.Interfaces.RentalApplications
{
    public interface IRentalApplicationRepository
    {
        Task<RentalApplication?> GetByIdAsync(int id);
        Task<IEnumerable<RentalApplication>> GetAllAsync();
        Task<IEnumerable<RentalApplication>> GetByUserIdAsync(int userId);
        Task AddAsync(RentalApplication rentalApplication);
        Task UpdateAsync(RentalApplication rentalApplication);
        Task<IEnumerable<RentalApplication>> GetByProductIdAsync(int productId);
        Task DeleteAsync(int id);
    }
}
