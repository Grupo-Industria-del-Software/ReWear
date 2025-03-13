using Application.DTOs.Status;
using Application.Interfaces.Categories;
using Application.Interfaces.Status;
using Application.Services;
using Application.Services.CategoryServices;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies
{
    public static class StatusDependencyContainer
    {
        public static IServiceCollection addInfrastructure(this  IServiceCollection services)
        {
            // Status
            services.AddScoped(typeof(IStatusRepository<>), typeof(StatusRepository<>));
            services.AddScoped(typeof(IStatusService<,,>), typeof(StatusService<,,>));

            services.AddScoped<IStatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO>, StatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO>>();
            services.AddScoped<IStatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO>, StatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO>>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            
            return services;
        } 
    }
}
