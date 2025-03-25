using Application.DTOs.Auth;
using Application.DTOs.Products;
using Application.DTOs.Catalogs;

namespace Application.DTOs.RentalApplications
{
    public class RentalApplicationResponseDTO
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int RentalDays { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RequesterUserId { get; set; }
        public int ProductOwnerUserId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }

        public UserResponseDTO? RequesterUser { get; set; }
        public UserResponseDTO? ProductOwnerUser { get; set; }
        public ProductResponseDto? Product { get; set; }
        public CatalogResponseDTO? Status { get; set; }
    }
}
