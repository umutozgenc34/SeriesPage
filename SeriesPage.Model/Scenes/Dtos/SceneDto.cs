namespace SeriesPage.Model.Scenes.Dtos;

public sealed record SceneDto
{
    public int Id { get; init; }
    public string Description { get; init; }
    public string VideoUrl { get; init; }
}
