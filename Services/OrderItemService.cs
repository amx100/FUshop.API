using Contract.DataTransferObject;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Services
{
    public class OrderItemService(IRepositoryManager repositoryManager) : IOrderItemService
    {
        public async Task<GeneralResponseDto> Create(OrderItemCreateDto orderItemDto, CancellationToken cancellationToken = default)
        {
            try
            {
                // Provera da li narudžbina postoji
                var order = await repositoryManager.OrderRepository.GetById(orderItemDto.OrderId, cancellationToken);
                if (order == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Order not found." };
                }

                // Provera da li proizvod postoji
                var product = await repositoryManager.ProductRepository.GetById(orderItemDto.ProductId, cancellationToken);
                if (product == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product not found." };
                }

                // Provera da li veličina postoji
                var size = await repositoryManager.SizeRepository.GetById(orderItemDto.SizeId, cancellationToken);
                if (size == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }

                var orderItem = new OrderItem
                {
                    OrderId = orderItemDto.OrderId,
                    ProductId = orderItemDto.ProductId,
                    SizeId = orderItemDto.SizeId,
                    Quantity = orderItemDto.Quantity,
                    CreatedAt = DateTime.UtcNow
                };

                repositoryManager.OrderItemRepository.Create(orderItem);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Order item created successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error creating order item: {ex.Message}" };
            }
        }

        public async Task<IEnumerable<OrderItemDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var orderItems = await repositoryManager.OrderItemRepository.GetAll(cancellationToken);
            var orderItemDtos = orderItems.Select(oi => new OrderItemDto
            {
                OrderItemId = oi.OrderItemId,
                OrderId = oi.OrderId,
                ProductId = oi.ProductId,
                SizeId = oi.SizeId,
                Quantity = oi.Quantity,

            });
            return orderItemDtos;
        }

        public async Task<GeneralResponseDto> GetById(int orderItemId, CancellationToken cancellationToken = default)
        {
            var orderItem = await repositoryManager.OrderItemRepository.GetById(orderItemId, cancellationToken);
            if (orderItem == null)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = "Order item not found." };
            }

            var orderItemDto = new OrderItemDto
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                SizeId = orderItem.SizeId,
                Quantity = orderItem.Quantity,

            };

            return new GeneralResponseDto
            {
                Data = orderItemDto,
                IsSuccess = true,
                Message = "Order item found successfully."
            };
        }

        public async Task<GeneralResponseDto> Update(int orderItemId, OrderItemUpdateDto orderItemDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingOrderItem = await repositoryManager.OrderItemRepository.GetById(orderItemId, cancellationToken);
                if (existingOrderItem == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Order item not found." };
                }

                // Provera povezanih entiteta
                var product = await repositoryManager.ProductRepository.GetById(orderItemDto.ProductId, cancellationToken);
                if (product == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product not found." };
                }

                var size = await repositoryManager.SizeRepository.GetById(orderItemDto.SizeId, cancellationToken);
                if (size == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }
                existingOrderItem.ProductId = orderItemDto.ProductId;
                existingOrderItem.SizeId = orderItemDto.SizeId;
                existingOrderItem.Quantity = orderItemDto.Quantity;

                repositoryManager.OrderItemRepository.Update(existingOrderItem);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Order item updated successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error updating order item: {ex.Message}" };
            }
        }

        public async Task<GeneralResponseDto> Delete(int orderItemId, CancellationToken cancellationToken = default)
        {
            try
            {
                var orderItem = await repositoryManager.OrderItemRepository.GetById(orderItemId, cancellationToken);
                if (orderItem == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Order item not found." };
                }

                repositoryManager.OrderItemRepository.Delete(orderItem);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Order item deleted successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error deleting order item: {ex.Message}" };
            }
        }
    }
}
