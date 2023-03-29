namespace GrindingCity.Infrastructure.Shared;

using System.Reflection;
using Building.Providers;
using Domain.Building.Providers;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        return collection.AddScoped<IBuildingRepository, BuildingRepository>()
            .AddMediatR(e => e.RegisterServicesFromAssemblies(
                Assembly.GetAssembly(typeof(BuildingEntity))!,
                Assembly.GetExecutingAssembly()));;
    }
}