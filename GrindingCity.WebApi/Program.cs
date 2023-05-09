using GrindingCity.Core.District;
using GrindingCity.Core.Extensions.Enum;
using GrindingCity.Core.Extensions.Sort;
using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Interfaces.Repositories;
using GrindingCity.Domain.Interfaces.Services;
using GrindingCity.Infrastructure.Database;
using GrindingCity.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InMemoryDbContext>();

builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IResourcesRepository, ResourcesRepository>();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(
    Assembly.GetAssembly(typeof(QuickSortImplementation))));

//builder.Services.AddScoped<IBuildingRepository, BuildingRepository>()
//            .AddScoped<IDistrictRepository, DistrictRepository>()
//            .AddScoped<IDistrictService, DistrictService>()
//            .AddMediatR(e => e.RegisterServicesFromAssemblies(
//                Assembly.GetAssembly(typeof(QuickSortImplementation))!,
//                Assembly.GetExecutingAssembly()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();