using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using JncSofttek.Microservice.Repository.Repositories;
using JncSofttek.Microservice.Util.Helpers.Interfaces;
using JncSofttek.Microservice.Util.Helpers;
using Microsoft.EntityFrameworkCore;
using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.Repository;

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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
