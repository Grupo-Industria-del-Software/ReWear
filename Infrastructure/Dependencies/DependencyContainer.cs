using Application.DTOs.Catalogs;
using Application.Interfaces.Auth;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Chat;
using Application.Interfaces.Cloudinary;
using Application.Interfaces.Department;
using Application.Interfaces.Mappers;
using Application.Interfaces.Message;
using Application.Interfaces.Municipality;
using Application.Interfaces.Orders;
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
using Application.Services.Orders;
using Application.Services.Chat;
using Application.Services.Departments;
using Application.Services.Municipalities;
using Application.Services.Products;
using Application.Services.RefreshTokens;
using Application.Services.Users;
using Application.Services.Subscriptions;
using Application.Services.UserRoles;
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

            // UserRoles
            services.AddScoped<IUserRolesService, UserRolesService>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            
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
            services.AddScoped<IOrderMapper, OrderMapper>();

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

            // Orders
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            
            //Cloudinary
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            //Chat 
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatRepository, ChatRepository>();
            
            //Message
            services.AddScoped<IMessageRepository, MessageRepository>();
            return services;
        } 
    }
}
