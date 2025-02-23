using SeriesPage.Repository.Extensions;
using SeriesPage.Service;
using SeriesPage.Service.Extensions;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddRepositoryExtension(builder.Configuration).AddServiceExtension(typeof(ServiceAssembly));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
