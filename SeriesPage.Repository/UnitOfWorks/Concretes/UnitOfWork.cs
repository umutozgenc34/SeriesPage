using SeriesPage.Repository.Context;
using SeriesPage.Repository.UnitOfWorks.Abstracts;

namespace SeriesPage.Repository.UnitOfWorks.Concretes;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
    
}
