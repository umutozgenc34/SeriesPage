using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesPage.Model.UserReviews.Entities;

namespace SeriesPage.Repository.UserReviews.Configurations;

public class ReviewsConfiguration : IEntityTypeConfiguration<Reviews>
{
    public void Configure(EntityTypeBuilder<Reviews> builder)
    {
        builder.ToTable("UserReviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NickName).IsRequired();

        builder.Property(x => x.Email).HasMaxLength(255);

        builder.Property(x=> x.Title).IsRequired().HasMaxLength(255);

        builder.Property(x=> x.Content).IsRequired().HasMaxLength(3000);

        builder.Property(x => x.Rating).IsRequired();
    }
}
