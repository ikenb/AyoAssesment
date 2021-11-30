using ConvertMetricUnits.Core.Repository;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ConvertMetricUnits.Data.Mappings;
using ConvertMetricUnits.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using LoggerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MetricsPolicy",
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<ConvertMetricDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration.GetConnectionString("Redis");
        options.InstanceName = "RedisMetricDb";
    });


builder.Services.AddAutoMapper(typeof(DtoMapper));
builder.Services.AddScoped<ILengthRepository, LengthRepository>();
builder.Services.AddScoped<IWeightRepository, WeightRepository>();
builder.Services.AddScoped<ITemparatureRepository, TemparatureRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

var jwtSettingsSection = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<JWTSettings>(jwtSettingsSection);

var appSettings = jwtSettingsSection.Get<JWTSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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
