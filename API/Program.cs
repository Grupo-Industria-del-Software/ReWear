using API.Config;
using Infrastructure.Configurations;
using Infrastructure.Dependencies;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DbConfig();

// Add services to the container.
builder.Services.AddDbContext<AlqDbContext>(options => options.UseSqlServer(dbConfig.ConnectionString));

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddInfrastructure();

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins("http://localhost:3003") // Direcci�n del frontend
               .AllowAnyMethod() // Permite todos los m�todos HTTP (GET, POST, PUT, DELETE, etc.)
               .AllowAnyHeader() // Permite todos los encabezados
               .AllowCredentials(); // Permite credenciales (opcional, si usas autenticaci�n)
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();