using Contract;
using Contract.DataTransferObject;

namespace Services.Abstractions
{
    public interface IProductSizeService
    {
        Task<IEnumerable<ProductSizeDto>> GetAll(CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> GetById(int productSizeId, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Create(ProductSizeCreateDto productSizeDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Update(int productSizeId, ProductSizeUpdateDto productSizeDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Delete(int productSizeId, CancellationToken cancellationToken = default);
    }
}
