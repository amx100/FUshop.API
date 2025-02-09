using Domain.Repositories.Common;

namespace Persistance.Repositories.Common;

internal sealed class UnitOfWork(DataContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => dbContext.SaveChangesAsync(cancellationToken);
}