using Application.DTOs.Catalogs;
using Application.Interfaces.Auth;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Categories;
using Application.Interfaces.Cloudinary;
using Application.Interfaces.Conditions;
using Application.Interfaces.Department;
using Application.Interfaces.Mappers;
using Application.Interfaces.Municipality;
using Application.Interfaces.OrderTypes;
using Application.Interfaces.PaymentMethods;
using Application.Interfaces.Products;
using Application.Interfaces.RefreshTokens;
using Application.Interfaces.Subscriptions;
using Application.Interfaces.userRoles;
using Application.Interfaces.Users;
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
using Application.Services.RefreshTokens;
using Application.Services.Users;
using Application.Services.Subscriptions;
using Domain.Entities;
using Infrastructure.Payments;
using Infrastructure.Providers;
using Infrastructure.Repositories;
using Infrastructure.Services;
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
            
            // Utils
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IJwtService, JwtProvider>();
            
            // Products
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            // Mappers
            services.AddScoped<IProductMapper, ProductMapper>();
            
            // Payments
            services.AddScoped<IPaymentService, StripePaymentService>();
            
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            
            // Users
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            // Tokens
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            
            //Cloudinary
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            return services;
        } 
    }
}
