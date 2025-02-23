namespace SeriesPage.Model.Summaries.Dtos;

public sealed record SummaryDto
{
    public int Id { get; init; }
    public string Text { get; init; } = default!;
}
