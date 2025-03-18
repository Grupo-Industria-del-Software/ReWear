using Application.DTOs.Status;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.Interfaces.Conditions;
using Application.Interfaces.Department;
using Application.Interfaces.Municipality;
using Application.Interfaces.OrderTypes;
using Application.Interfaces.PaymentMethods;
using Application.Interfaces.Status;
using Application.Interfaces.userRoles;
using Application.Services;
using Application.Services.CategoryServices;
using Application.Services.DepartmentService;
using Application.Services.MunicipalityServices;
using Application.Services.OrderTypes;
using Application.Services.PaymentMethods;
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

            // PaymentMethods
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

            // Condition
            services.AddScoped<IConditionService, ConditionService>();
            services.AddScoped<IConditionRepository, ConditionRepository>();
            
            //Departmnet
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //Municipality
            services.AddScoped<IMunicipalityService, MunicipalityService>();
            services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
            return services;
        } 
    }
}
