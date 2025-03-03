namespace SeriesPage.Model.Awards.Dtos;

public sealed record UpdateAwardRequest(int Id,string Name,string WinnerName,string Category,int Year);

