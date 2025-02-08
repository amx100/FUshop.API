using Domain.Entities;
using MyProperty.API.Core.Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
