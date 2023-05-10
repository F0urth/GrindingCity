﻿using Domain.Buildings.Providers;
using Domain.Resources.Providers;
using GrindingCity.Infrastructure.Buildings.Providers;
using GrindingCity.Infrastructure.Resources.Providers;

namespace GrindingCity.Infrastructure.Shared;

using System.Reflection;
using Domain.Districts.Providers;
using Domain.Entities;
using GrindingCity.Infrastructure.Districts.Providers;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        return collection
            .AddScoped<IBuildingRepository, BuildingRepository>()
            .AddScoped<IResourceRepository, ResourceRepository>()
            .AddScoped<IDistrictRepository, DistrictRepository>()
            .AddMediatR(e => e.RegisterServicesFromAssemblies(
                Assembly.GetAssembly(typeof(BuildingEntity))!,
                Assembly.GetExecutingAssembly()));;
    }
}