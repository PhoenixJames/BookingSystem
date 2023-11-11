using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
// Database connection
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
builder.Services.AddDbContext<BookingSystemContext>(
      dbContextOptions => dbContextOptions
          .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
          .EnableSensitiveDataLogging() // <-- These two calls are optional but help
          .EnableDetailedErrors()
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
