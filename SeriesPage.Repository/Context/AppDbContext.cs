using Microsoft.EntityFrameworkCore;
using SeriesPage.Model.Casts.Entities;
using SeriesPage.Model.Episodes.Entites;
using SeriesPage.Model.Photos.Entities;
using SeriesPage.Model.Scenes.Entities;
using SeriesPage.Model.Seasons.Entities;
using SeriesPage.Model.Summaries.Entities;
using System.Reflection;

namespace SeriesPage.Repository.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Summary> Summaries { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Scene> Scenes { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
