using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using BookingSystem.Entities;
using BookingSystem.AutoMapper;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper
(
  typeof(UserMappingProfile),
  typeof(UserProfileMappingProfile),
  typeof(UserPackageMappingProfile)
);
// Database connection
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
builder.Services.AddDbContext<BookingSystemContext>(
      dbContextOptions => dbContextOptions
          .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
          .EnableSensitiveDataLogging() // <-- These two calls are optional but help
          .EnableDetailedErrors()
);
//Jwt Authentication 
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
   options.TokenValidationParameters = new TokenValidationParameters
   {
     ValidateIssuer = true,
     ValidateAudience = true,
     ValidateLifetime = true,
     ValidateIssuerSigningKey = true,
     ValidIssuer = jwtIssuer,
     ValidAudience = jwtIssuer,
     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
   };
 });
// Add Authorization On Swagger UI
builder.Services.AddSwaggerGen(option =>
{
  option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
  option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Please enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
  });
  option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Adding Reposiories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserPackageRepository, UserPackageRepository>();
builder.Services.AddScoped<IUserClassRepository, UserClassRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IWaitlistRepository, WaitlistRepository>();
// Adding Services
builder.Services.AddScoped<IPackageService, PackageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
