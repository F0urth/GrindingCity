﻿using GrindingCity.WebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace GrindingCity.WebApi.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
