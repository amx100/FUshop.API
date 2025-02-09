using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories
{
    public interface IProductSizeRepository : IRepositoryBase<ProductSize>
    {
        Task<IEnumerable<ProductSize>> GetAll(CancellationToken cancellationToken = default);
        Task<ProductSize> GetById(int productSizeId, CancellationToken cancellationToken = default);
        void CreateProductSize(ProductSize productSize, CancellationToken cancellationToken = default);
        void DeleteProductSize(ProductSize productSize, CancellationToken cancellationToken = default);
        void UpdateProductSize(ProductSize productSize, CancellationToken cancellationToken = default);
    }
}
