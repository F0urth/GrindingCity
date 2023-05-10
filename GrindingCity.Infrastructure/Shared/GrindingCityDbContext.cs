namespace GrindingCity.Infrastructure.Shared;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public sealed class GrindingCityDbContext : DbContext
{
    public DbSet<BuildingEntity> Building { get; set; } = default!;

    public DbSet<ResourceEntity> Resource { get; set; } = default!;

    public DbSet<DistrictEntity> District { get; set; } = default!;

    public GrindingCityDbContext(DbContextOptions options) : base(options) { }
}