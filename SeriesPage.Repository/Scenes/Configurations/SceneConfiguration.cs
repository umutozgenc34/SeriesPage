using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesPage.Model.Scenes.Entities;

namespace SeriesPage.Repository.Scenes.Configurations;

public class SceneConfiguration : IEntityTypeConfiguration<Scene>
{
    public void Configure(EntityTypeBuilder<Scene> builder)
    {
        builder.ToTable("Scenes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description).HasMaxLength(500);

        builder.Property(x => x.VideoUrl);
    }
}
