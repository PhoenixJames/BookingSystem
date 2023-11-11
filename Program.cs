using Microsoft.EntityFrameworkCore;
using BookingSystem.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Database connection
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
builder.Services.AddDbContext<BookingSystemContext>(
      dbContextOptions => dbContextOptions
          .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
          .EnableSensitiveDataLogging() // <-- These two calls are optional but help
          .EnableDetailedErrors()
);
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
