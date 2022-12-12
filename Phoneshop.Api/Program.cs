using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Phoneshop.Business;
using Phoneshop.Contracts;
using Phoneshop.Data;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using Phoneshop.Shared.Auth;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddDbContext<EntityFrameworkDataContext>();
builder.Services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IRepository<Phone>, Repository<Phone>>();
builder.Services.AddScoped<IRepository<Brand>, Repository<Brand>>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InitAuth(builder);
var app = builder.Build();

//JWT authentication
static void InitAuth(WebApplicationBuilder builder)
{
    builder.Services.AddIdentity<AppUser, AppUserRole>()
                    .AddEntityFrameworkStores<EntityFrameworkDataContext>()
                    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

    var jwtTokenConfig = builder.Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
    builder.Services.AddSingleton(jwtTokenConfig);

    builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtTokenConfig.Issuer,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
            ValidateAudience = true,
            ValidAudience = jwtTokenConfig.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });
}

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
