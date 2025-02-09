using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Common;

namespace Persistance.Repositories;

public class SizeRepository(DataContext dataContext) : RepositoryBase<Size>(dataContext), ISizeRepository
{
    public void CreateSize(Size size, CancellationToken cancellationToken = default) => Create(size);
    public void DeleteSize(Size size, CancellationToken cancellationToken = default) => Delete(size);
    public void UpdateSize(Size size, CancellationToken cancellationToken = default) => Update(size);
    public async Task<IEnumerable<Size>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<Size> GetById(int sizeId, CancellationToken cancellationToken = default) => await FindByCondition(s => s.SizeId == sizeId).FirstOrDefaultAsync(cancellationToken);
}
