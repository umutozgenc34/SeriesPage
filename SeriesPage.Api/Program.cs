using SeriesPage.Repository.Extensions;
using SeriesPage.Service;
using SeriesPage.Service.Extensions;
using Shared.Extensions;
using Shared.Middlewares;

DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

const string FrontendCorsPolicy = "Frontend";

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithExposedHeaders("Location"));
});

builder.Services.AddControllers();

builder.Services.AddRepositoryExtension(builder.Configuration)
    .AddServiceExtension(typeof(ServiceAssembly))
    .AddSharedExtension(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(FrontendCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
