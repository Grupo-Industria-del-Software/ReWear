using Application.DTOs.Catalogs;
using Application.Interfaces;
using Application.Interfaces.Auth;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Categories;
using Application.Interfaces.Conditions;
using Application.Interfaces.Department;
using Application.Interfaces.Mappers;
using Application.Interfaces.Municipality;
using Application.Interfaces.OrderTypes;
using Application.Interfaces.PaymentMethods;
using Application.Interfaces.Products;
using Application.Interfaces.userRoles;
using Application.Interfaces.Utils;
using Application.Mappers;
using Application.Services;
using Application.Services.Auth;
using Application.Services.CategoryServices;
using Application.Services.DepartmentService;
using Application.Services.MunicipalityServices;
using Application.Services.OrderTypes;
using Application.Services.PaymentMethods;
using Application.Services.Products;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(this  IServiceCollection services)
        {
            // Status
            services.AddScoped(typeof(ICatalogRepository<>), typeof(CatalogRepository<>));
            services.AddScoped(typeof(ICatalogService<,,>), typeof(CatalogService<,,>));

            services.AddScoped<ICatalogService<OrderStatus, CatalogRequestDTO, CatalogResponseDTO>, CatalogService<OrderStatus, CatalogRequestDTO, CatalogResponseDTO>>();
            services.AddScoped<ICatalogService<PaymentStatus, CatalogRequestDTO, CatalogResponseDTO>, CatalogService<PaymentStatus, CatalogRequestDTO, CatalogResponseDTO>>();

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
            
            // Auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            
            // Utils
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IJwtService, JwtService>();
            
            // Products
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            // Mappers
            services.AddScoped<IProductMapper, ProductMapper>();
            return services;
        } 
    }
}
