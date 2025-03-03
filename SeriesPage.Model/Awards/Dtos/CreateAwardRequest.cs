namespace SeriesPage.Model.Awards.Dtos;

public sealed record CreateAwardRequest(string Name,string WinnerName,string Category,int Year);
