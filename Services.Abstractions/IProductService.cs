using Contract;
using Contract.DataTransferObject;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> GetById(int productId, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Create(ProductCreateDto productDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Update(int productId, ProductUpdateDto productDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Delete(int productId, CancellationToken cancellationToken = default);
    }
}
