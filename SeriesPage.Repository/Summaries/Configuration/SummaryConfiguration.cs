using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesPage.Model.Summaries.Entities;

namespace SeriesPage.Repository.Summaries.Configuration;

public class SummaryConfiguration : IEntityTypeConfiguration<Summary>
{
    public void Configure(EntityTypeBuilder<Summary> builder)
    {
        builder.ToTable("Summary");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text).IsRequired()
            .HasMaxLength(5000);
    }
}
