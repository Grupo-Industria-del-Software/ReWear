using Application.DTOs.Status;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.Interfaces.OrderTypes;
using Application.Interfaces.Status;
using Application.Interfaces.userRoles;
using Application.Services;
using Application.Services.CategoryServices;
using Application.Services.OrderTypes;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(this  IServiceCollection services)
        {
            // Status
            services.AddScoped(typeof(IStatusRepository<>), typeof(StatusRepository<>));
            services.AddScoped(typeof(IStatusService<,,>), typeof(StatusService<,,>));

            services.AddScoped<IStatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO>, StatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO>>();
            services.AddScoped<IStatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO>, StatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO>>();

            // Category
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>(); 

            // OrderType
            services.AddScoped<IOrderTypeService, OrderTypeService>();
            services.AddScoped<IOrderTypeRepository, OrderTypeRepository>();

            // UserRoles
            services.AddScoped<IUserRolesService, UserRolesService>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();

            return services;
        } 
    }
}
