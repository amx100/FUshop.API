using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Common;

namespace Persistance.Repositories;

public class ProductRepository(DataContext dataContext) : RepositoryBase<Product>(dataContext), IProductRepository
{
    public void CreateProduct(Product product, CancellationToken cancellationToken = default) => Create(product);
    public void DeleteProduct(Product product, CancellationToken cancellationToken = default) => Delete(product);
    public void UpdateProduct(Product product, CancellationToken cancellationToken = default) => Update(product);
    public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<Product> GetById(int productId, CancellationToken cancellationToken = default) => await FindByCondition(p => p.ProductId == productId).FirstOrDefaultAsync(cancellationToken);
    public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId, CancellationToken cancellationToken = default) => await FindByCondition(p => p.CategoryId == categoryId).ToListAsync(cancellationToken);
}
