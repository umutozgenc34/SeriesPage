namespace SeriesPage.Model.Casts.Dtos;

public sealed record CastDto
{
    public int Id { get; init; }
    public string NameInTheSeries { get; init; } 
    public string RealName { get; init; } 
    public string? ImageUrl { get; init; }
}
