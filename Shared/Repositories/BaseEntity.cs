namespace Shared.Repositories;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; } = default!;
}
