namespace SeriesPage.Model.Photos.Dtos;

public sealed record PhotoDto
{
    public int Id { get; init; }
    public string ImageUrl { get; init; }
}
