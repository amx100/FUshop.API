using Contract;
using Contract.DataTransferObject;

namespace Services.Abstractions
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAll(CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> GetById(int orderItemId, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Create(OrderItemCreateDto orderItemDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Update(int orderItemId, OrderItemUpdateDto orderItemDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Delete(int orderItemId, CancellationToken cancellationToken = default);
    }
}
