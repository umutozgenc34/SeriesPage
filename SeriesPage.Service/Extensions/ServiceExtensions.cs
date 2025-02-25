using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SeriesPage.Service.Casts.Abstracts;
using SeriesPage.Service.Casts.Concretes;
using SeriesPage.Service.Summaries.Abstracts;
using SeriesPage.Service.Summaries.Concretes;
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
            

        return services;
    }
}
