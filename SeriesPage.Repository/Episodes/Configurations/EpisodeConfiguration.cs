using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesPage.Model.Episodes.Entites;

namespace SeriesPage.Repository.Episodes.Configurations;

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.ToTable("Episodes");

        builder.HasKey(x => x.Id);

        builder.Property(x=> x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.EpisodeNumber)
            .IsRequired();

        builder.Property(x => x.SeasonId)
            .IsRequired();

        builder.Property(x => x.VideoUrl);

        builder.HasOne(x => x.Season)
            .WithMany(x => x.Episodes)
            .HasForeignKey(x => x.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(x => x.Season).AutoInclude();

    }
}
