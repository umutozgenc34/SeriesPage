namespace SeriesPage.Model.UserReviews.Dtos;

public sealed record UpdateReviewsRequest(int Id,string NickName,string? Email,string Title,string Content,float Rating);
