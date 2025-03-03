namespace SeriesPage.Model.Awards.Dtos;

public sealed record AwardDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string WinnerName { get; init; }
    public string Category { get; init; }
    public int Year { get; init; }
}

