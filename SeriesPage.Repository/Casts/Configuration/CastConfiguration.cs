using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesPage.Model.Casts.Entities;

namespace SeriesPage.Repository.Casts.Configuration;

public class CastConfiguration : IEntityTypeConfiguration<Cast>
{
    public void Configure(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable("Cast");

        builder.HasKey(x => x.Id);

        builder.Property(x=> x.NameInTheSeries).IsRequired()
            .HasMaxLength(100);

        builder.Property(x=> x.RealName).IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.ImageUrl);
        
    }
}
