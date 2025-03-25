using Application.DTOs.Auth;
using Application.DTOs.Catalogs;
using Application.DTOs.RentalApplications;
using Application.Interfaces.Mappers;
using Domain.Entities;

namespace Application.Mappers
{
    public class RentalApplicationMapper : IRentalApplicationMapper
    {
        private readonly IProductMapper _productMapper;
        private readonly IUserMapper _userMapper;

        public RentalApplicationMapper(IProductMapper productMapper, IUserMapper userMapper)
        {
            _productMapper = productMapper;
            _userMapper = userMapper;
        }

        public RentalApplicationResponseDTO MapToDto(RentalApplication app, RentalApplicationStatus status)
        {
            return new RentalApplicationResponseDTO
            {
                Id = app.Id,
                StartDate = app.StartDate,
                EndDate = app.EndDate,
                RentalDays = app.EndDate.DayNumber - app.StartDate.DayNumber,
                TotalPrice = app.TotalPrice,
                CreatedAt = app.CreatedAt,
                RequesterUserId = app.RequesterUserId,
                ProductOwnerUserId = app.ProductOwnerUserId,
                ProductId = app.ProductId,
                StatusId = app.StatusId,
                Status = status != null ? new CatalogResponseDTO
                {
                    Id = status.Id,
                    Label = status.Label
                } : null,
                RequesterUser = _userMapper.MapToDto(app.RequesterUser),
                ProductOwnerUser = _userMapper.MapToDto(app.RequesterUser),
                Product = app.Product != null ? _productMapper.ToDto(app.Product) : null 
            };
        }
    }
}