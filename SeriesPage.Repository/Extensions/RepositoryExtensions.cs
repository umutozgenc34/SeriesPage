﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeriesPage.Repository.Casts.Abstracts;
using SeriesPage.Repository.Casts.Concretes;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Scenes.Abstracts;
using SeriesPage.Repository.Scenes.Concretes;
using SeriesPage.Repository.Seasons.Abstracts;
using SeriesPage.Repository.Seasons.Concretes;
using SeriesPage.Repository.Summaries.Abstracts;
using SeriesPage.Repository.Summaries.Concretes;
using SeriesPage.Repository.UnitOfWorks.Abstracts;
using SeriesPage.Repository.UnitOfWorks.Concretes;

namespace SeriesPage.Repository.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryExtension(this IServiceCollection services ,IConfiguration configuration)
    {
        services.AddScoped<ISummaryRepository, SummaryRepository>();
        services.AddScoped<ICastRepository, CastRepository>();
        services.AddScoped<ISceneRepository, SceneRepository>();
        services.AddScoped<ISeasonRepository, SeasonRepository>();


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        return services;
    }
}
