using Application.DTOs.Catalogs;
using Application.DTOs.RentalApplications;
using Application.DTOs.Auth;
using Application.DTOs.Products;
using Application.DTOs.CategoriesDTO;
using Application.DTOs.ConditionsDTOs;
using Application.Interfaces.Catalogs;
using Application.Interfaces.RentalApplications;
using Application.Interfaces.Mappers;
using Domain.Entities;
using RentalApplicationStatus = Domain.Entities.RentalApplicationStatus;
using Application.Interfaces.Products;

namespace Application.Services.RentalApplications
{
    public class RentalApplicationService : IRentalApplicationService
    {
        private readonly IRentalApplicationRepository _rentalApplicationRepository;
        private readonly ICatalogRepository<RentalApplicationStatus> _applicationStatusRepository;
        private readonly IProductRepository _productRepository;
        private readonly IRentalApplicationMapper _mapper;
        public RentalApplicationService(
        IRentalApplicationRepository rentalApplicationRepository,
        ICatalogRepository<RentalApplicationStatus> applicationStatusRepository,
        IProductRepository productRepository,
        IRentalApplicationMapper mapper)
        {
            _rentalApplicationRepository = rentalApplicationRepository;
            _applicationStatusRepository = applicationStatusRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<RentalApplicationResponseDTO> CreateRentalApplicationAsync(
        RentalApplicationRequestDTO request, int requesterUserId)
        {
            if (request.RequesterUserId <= 0)
                throw new ArgumentException("Invalid RequesterUserId");

            var status = await _applicationStatusRepository.GetByIdAsync(request.StatusId);
            if (status == null)
                throw new ArgumentException("Invalid status ID");

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new ArgumentException("Invalid product ID");

            if (!product.PricePerDay.HasValue)
                throw new ArgumentException("El precio por día no está definido para este producto");

            var rentalDays = request.EndDate.DayNumber - request.StartDate.DayNumber;
            if (rentalDays <= 0)
                throw new ArgumentException("EndDate must be after StartDate");

            var productOwnerUserId = product.User.Id;

            var calculatedTotalPrice = rentalDays * product.PricePerDay.Value;

            var rentalApplication = new RentalApplication(
                request.RequesterUserId,
                request.ProductOwnerUserId,
                request.ProductId,
                request.StartDate,
                request.EndDate,
                calculatedTotalPrice, 
                request.StatusId
            );

            await _rentalApplicationRepository.AddAsync(rentalApplication);

            var createdApplication = await _rentalApplicationRepository.GetByIdAsync(rentalApplication.Id);
            
            return _mapper.MapToDto(createdApplication, status); 
        }

        public async Task<RentalApplicationResponseDTO> GetRentalApplicationByIdAsync(int id)
        {
            var rentalApplication = await _rentalApplicationRepository.GetByIdAsync(id);
            if (rentalApplication == null) return null;

            var status = await _applicationStatusRepository.GetByIdAsync(rentalApplication.StatusId);

            return _mapper.MapToDto(rentalApplication, status);
        }

        public async Task<IEnumerable<RentalApplicationResponseDTO>> GetUserRentalApplicationsAsync(int userId)
        {
            var applications = await _rentalApplicationRepository.GetByUserIdAsync(userId);
            var result = new List<RentalApplicationResponseDTO>();

            foreach (var app in applications)
            {
                var status = await _applicationStatusRepository.GetByIdAsync(app.StatusId);
                result.Add(_mapper.MapToDto(app, status));
            }

            return result;
        }

        public async Task UpdateRentalApplicationStatusAsync(int applicationId, int statusId)
{
            var newStatus = await _applicationStatusRepository.GetByIdAsync(statusId);
    
            if (newStatus == null)
                throw new ArgumentException($"Status ID {statusId} not found");

            var application = await _rentalApplicationRepository.GetByIdAsync(applicationId);
            
            if (application == null)
                throw new ArgumentException("Application not found");

            application.StatusId = statusId;
            await _rentalApplicationRepository.UpdateAsync(application);
}

        public async Task<IEnumerable<RentalApplicationResponseDTO>> GetRentalApplicationsByProductIdAsync(int productId)
        {
            var applications = await _rentalApplicationRepository.GetByProductIdAsync(productId);
            var result = new List<RentalApplicationResponseDTO>();

            foreach (var app in applications)
            {
                var status = await _applicationStatusRepository.GetByIdAsync(app.StatusId);
                result.Add(_mapper.MapToDto(app, status));
            }

            return result;
        }

        public async Task<RentalApplicationResponseDTO> DeleteRentalApplicationAsync(int applicationId, int userId)
        {
            var application = await _rentalApplicationRepository.GetByIdAsync(applicationId);
            if (application == null)
                throw new ArgumentException("Aplicación no encontrada");

            await _rentalApplicationRepository.DeleteAsync(application.Id);

            var status = await _applicationStatusRepository.GetByIdAsync(application.StatusId);

            return _mapper.MapToDto(application, status);
        }
    }
}