using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeriesPage.Model.UserReviews.Entities;
using SeriesPage.Repository.Awards.Abstracts;
using SeriesPage.Repository.Awards.Concretes;
using SeriesPage.Repository.Casts.Abstracts;
using SeriesPage.Repository.Casts.Concretes;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Episodes.Abstracts;
using SeriesPage.Repository.Episodes.Concretes;
using SeriesPage.Repository.Photos.Abstracts;
using SeriesPage.Repository.Photos.Concretes;
using SeriesPage.Repository.Scenes.Abstracts;
using SeriesPage.Repository.Scenes.Concretes;
using SeriesPage.Repository.Seasons.Abstracts;
using SeriesPage.Repository.Seasons.Concretes;
using SeriesPage.Repository.Summaries.Abstracts;
using SeriesPage.Repository.Summaries.Concretes;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Concretes;
using SeriesPage.Repository.UserReviews.Abstracts;
using SeriesPage.Repository.UserReviews.Concretes;

namespace SeriesPage.Repository.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryExtension(this IServiceCollection services ,IConfiguration configuration)
    {
        services.AddScoped<ISummaryRepository, SummaryRepository>();
        services.AddScoped<ICastRepository, CastRepository>();
        services.AddScoped<ISceneRepository, SceneRepository>();
        services.AddScoped<ISeasonRepository, SeasonRepository>();
        services.AddScoped<IEpisodeRepository, EpisodeRepository>();
        services.Decorate<IEpisodeRepository,EpisodeRepositoryWithCache>();
        services.AddScoped<IPhotoRepository,PhotoRepository>();
        services.AddScoped<IReviewsRepository, ReviewsRepository>();
        services.AddScoped<IAwardRepository,AwardRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = configuration.GetConnectionString("Redis");
        });

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        return services;
    }
}
