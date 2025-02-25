using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services.Cloudinaryy.Abstracts;
using Shared.Services.Cloudinaryy.Concretes;
using Shared.Services.Cloudinaryy.Settings;

namespace Shared.Extensions;

public static class SharedExtensions
{
    public static IServiceCollection AddSharedExtension(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.Configure<CloudinarySettings>(options =>
            configuration.GetSection("CloudinarySettings").Bind(options));
        return services;
    }
}
