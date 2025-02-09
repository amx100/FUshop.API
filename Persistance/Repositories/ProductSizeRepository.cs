using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Common;

namespace Persistance.Repositories;

public class ProductSizeRepository(DataContext dataContext) : RepositoryBase<ProductSize>(dataContext), IProductSizeRepository
{
    public void CreateProductSize(ProductSize productSize, CancellationToken cancellationToken = default) => Create(productSize);
    public void DeleteProductSize(ProductSize productSize, CancellationToken cancellationToken = default) => Delete(productSize);
    public void UpdateProductSize(ProductSize productSize, CancellationToken cancellationToken = default) => Update(productSize);
    public async Task<IEnumerable<ProductSize>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<ProductSize> GetById(int productSizeId, CancellationToken cancellationToken = default) => await FindByCondition(ps => ps.ProductSizeId == productSizeId).FirstOrDefaultAsync(cancellationToken);
    
    public async Task<ProductSize?> GetProductSizeByProductAndSize(int productId, int sizeId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(ps => ps.ProductId == productId && ps.SizeId == sizeId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
