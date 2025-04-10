using API.Config;
using API.Filters;
using API.Hubs;
using Infrastructure.Configurations;
using Infrastructure.Dependencies;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DbConfig();

builder.WebHost.ConfigureKestrel(options =>
{
    options.Configure(builder.Configuration.GetSection("Kestrel"));
});


// Add services to the container.
builder.Services.AddDbContext<AlqDbContext>(options => options.UseSqlServer(dbConfig.ConnectionString));

builder.Services.AddJwtConfiguration(builder.Configuration);

StripeConfiguration.ConfigureStripe(builder.Configuration);

builder.Services.AddInfrastructure();

// Agregar SignalR para comunicación en tiempo real
builder.Services.AddSignalR();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Filters
builder.Services.AddScoped<SubscriptionRequirementFilter>();

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireSellerRole", policy => policy.RequireRole("Seller"));
    options.AddPolicy("RequireCustomerRole", policy => policy.RequireRole("Customer"));
    options.AddPolicy("SellerOrCustomer", policy => policy.RequireRole("Seller", "Customer"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar CORS
app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

// Mapeo del hub de SignalR 
app.MapHub<ChatHub>("/chatHub");
app.Run();