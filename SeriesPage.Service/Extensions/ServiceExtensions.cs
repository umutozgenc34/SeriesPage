﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SeriesPage.Repository.Episodes.Abstracts;
using SeriesPage.Service.Awards.Abstracts;
using SeriesPage.Service.Awards.Concretes;
using SeriesPage.Service.Casts.Abstracts;
using SeriesPage.Service.Casts.Concretes;
using SeriesPage.Service.Episodes.Abstracts;
using SeriesPage.Service.Episodes.Concretes;
using SeriesPage.Service.Photos.Abstracts;
using SeriesPage.Service.Photos.Concretes;
using SeriesPage.Service.Scenes.Abstracts;
using SeriesPage.Service.Scenes.Concretes;
using SeriesPage.Service.Seasons.Abstracts;
using SeriesPage.Service.Seasons.Concretes;
using SeriesPage.Service.Summaries.Abstracts;
using SeriesPage.Service.Summaries.Concretes;
using SeriesPage.Service.UserReviews.Abstracts;
using SeriesPage.Service.UserReviews.Concretes;
using System.Reflection;

namespace SeriesPage.Service.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServiceExtension(this IServiceCollection services,Type assembly)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);

        services.AddScoped<ISummaryService, SummaryService>();
        services.AddScoped<ICastService, CastService>();
        services.AddScoped<ISceneService, SceneService>();
        services.AddScoped<ISeasonService, SeasonService>();
        services.AddScoped<IEpisodeService,EpisodeService>();
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<IReviewsService, ReviewsService>();
        services.AddScoped<IAwardService,AwardService>();
            

        return services;
    }
}
