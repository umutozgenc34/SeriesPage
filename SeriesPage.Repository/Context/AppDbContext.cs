﻿using Microsoft.EntityFrameworkCore;
using SeriesPage.Model.Casts.Entities;
using SeriesPage.Model.Summaries.Entities;
using System.Reflection;

namespace SeriesPage.Repository.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Summary> Summaries { get; set; }
    public DbSet<Cast> Casts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
