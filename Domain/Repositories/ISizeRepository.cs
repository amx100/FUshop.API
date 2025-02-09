using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories
{
    public interface ISizeRepository : IRepositoryBase<Size>
    {
        Task<IEnumerable<Size>> GetAll(CancellationToken cancellationToken = default);
        Task<Size> GetById(int sizeId, CancellationToken cancellationToken = default);
        void CreateSize(Size size, CancellationToken cancellationToken = default);
        void DeleteSize(Size size, CancellationToken cancellationToken = default);
        void UpdateSize(Size size, CancellationToken cancellationToken = default);
    }
}
