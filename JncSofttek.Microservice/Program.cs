using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.Repository;
using JncSofttek.Microservice.Repository.Repositories;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using JncSofttek.Microservice.Util.Helpers;
using JncSofttek.Microservice.Util.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JncSofttekContext>(
    opt => opt.UseInMemoryDatabase(databaseName: "DBSofttekMemory"),
    ServiceLifetime.Scoped, ServiceLifetime.Scoped);

builder.Services.AddSingleton<IHelperValidation, HelperValidation>();
builder.Services.AddSingleton<IHelperToken, HelperToken>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration.GetValue<string>("JwtBearer:Issuer"),
                        ValidAudience = builder.Configuration.GetValue<string>("JwtBearer:Audience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(builder.Configuration.GetValue<string>("JwtBearer:SecurityKey")))
                    };
                });


var app = builder.Build();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<JncSofttekContext>();
await SeedData.AddDefaulDataAsync(context);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
