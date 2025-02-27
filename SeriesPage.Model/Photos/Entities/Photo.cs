using Shared.Repositories;

namespace SeriesPage.Model.Photos.Entities;

public class Photo : BaseEntity<int>
{
    public string ImageUrl { get; set; } = default!;
}
