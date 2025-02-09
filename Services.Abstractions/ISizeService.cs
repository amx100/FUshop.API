using Contract;
using Contract.DataTransferObject;

namespace Services.Abstractions
{
    public interface ISizeService
    {
        Task<IEnumerable<SizeDto>> GetAll(CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> GetById(int sizeId, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Create(SizeCreateDto sizeDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Update(int sizeId, SizeUpdateDto sizeDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Delete(int sizeId, CancellationToken cancellationToken = default);
    }
}
