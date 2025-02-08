using Domain.Entities;
using MyProperty.API.Core.Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IProductRepository : IRepositoryBase<Product>
{
    Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> GetByCategoryId(int categoryId, CancellationToken cancellationToken = default);

    Task<Product> GetById(int propertyId, CancellationToken cancellationToken = default);

    void CreateProduct(Product property, CancellationToken cancellationToken = default);

    void DeleteProduct(Product property, CancellationToken cancellationToken = default);

    void UpdateProduct(Product property, CancellationToken cancellationToken = default);
}