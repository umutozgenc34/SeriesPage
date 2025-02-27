namespace SeriesPage.Model.UserReviews.Dtos;

public sealed record CreateReviewsRequest(string NickName,string? Email,string Title,string Content,float Rating);


