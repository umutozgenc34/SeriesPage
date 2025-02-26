using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesPage.Model.Seasons.Entities;

namespace SeriesPage.Repository.Seasons.Configurations;

public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.ToTable("Seasons");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SeasonNumber)
            .IsRequired();

        builder.HasMany(x=> x.Episodes)
            .WithOne(x=> x.Season)
            .HasForeignKey(x=> x.SeasonId)
            .OnDelete(DeleteBehavior.Cascade);
            
    }
}
