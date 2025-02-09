using Contract;
using Contract.DataTransferObject;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> GetById(int orderId, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Create(OrderCreateDto orderDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Update(int orderId, OrderUpdateDto orderDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Delete(int orderId, CancellationToken cancellationToken = default);
    }
}
