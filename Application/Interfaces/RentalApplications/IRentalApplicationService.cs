using Application.DTOs.RentalApplications;
using Application.DTOs.Catalogs;

namespace Application.Interfaces.RentalApplications
{
    public interface IRentalApplicationService
    {
        Task<RentalApplicationResponseDTO> CreateRentalApplicationAsync(RentalApplicationRequestDTO request, int requesterUserId);

        Task<RentalApplicationResponseDTO> GetRentalApplicationByIdAsync(int id);

        Task<IEnumerable<RentalApplicationResponseDTO>> GetUserRentalApplicationsAsync(int userId);

        Task UpdateRentalApplicationStatusAsync(int applicationId, int statusId);

        Task<IEnumerable<RentalApplicationResponseDTO>> GetRentalApplicationsByProductIdAsync(int productId);

        Task<RentalApplicationResponseDTO> DeleteRentalApplicationAsync(int applicationId, int userId);
    }
}
