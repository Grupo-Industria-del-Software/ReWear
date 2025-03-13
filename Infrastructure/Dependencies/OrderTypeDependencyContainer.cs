using Application.DTOs.OrderTypes;
using Application.Interfaces.OrderTypes;
using Application.Services;
using Application.Services.OrderTypes;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies
{
    public static class OrderTypeDependencyContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IOrderTypeService, OrderTypeService>();
            services.AddScoped<IOrderTypeRepository, OrderTypeRepository>();

            return services;
        }
    }
}
