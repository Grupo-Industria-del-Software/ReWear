using Application.DTOs.Status;
using Application.Interfaces.Status;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dependencies
{
    public static class StatusDependencyContainer
    {
        public static IServiceCollection addInfrastructure(this  IServiceCollection services)
        {
            services.AddScoped(typeof(IStatusRepository<>), typeof(StatusRepository<>));
            services.AddScoped(typeof(IStatusService<,,>), typeof(StatusService<,,>));

            services.AddScoped<IStatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO>, StatusService<OrderStatus, StatusRequestDTO, StatusResponseDTO>>();
            services.AddScoped<IStatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO>, StatusService<PaymentStatus, StatusRequestDTO, StatusResponseDTO>>();

            return services;
        } 
    }
}
