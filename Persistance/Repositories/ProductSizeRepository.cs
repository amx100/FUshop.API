using Domain.Entities;
using Domain.Repositories;
using MyProperty.API.Infrastructure.Persistence.Persistence.Repositories.Common;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class ProductSizeRepository(DataContext dataContext) : RepositoryBase<ProductSize>(dataContext), IProductSizeRepository
{
    public void CreateProductSize(ProductSize productSize, CancellationToken cancellationToken = default) => Create(productSize);
    public void DeleteProductSize(ProductSize productSize, CancellationToken cancellationToken = default) => Delete(productSize);
    public void UpdateProductSize(ProductSize productSize, CancellationToken cancellationToken = default) => Update(productSize);
    public async Task<IEnumerable<ProductSize>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<ProductSize> GetById(int productSizeId, CancellationToken cancellationToken = default) => await FindByCondition(ps => ps.Id == productSizeId).FirstOrDefaultAsync(cancellationToken);
}
