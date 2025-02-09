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
                // Check if order exists
                var order = await repositoryManager.OrderRepository.GetById(orderItemDto.OrderId, cancellationToken);
                if (order == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Order not found." };
                }

                // Check if product exists and get its price
                var product = await repositoryManager.ProductRepository.GetById(orderItemDto.ProductId, cancellationToken);
                if (product == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product not found." };
                }

                // Check if size exists
                var size = await repositoryManager.SizeRepository.GetById(orderItemDto.SizeId, cancellationToken);
                if (size == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }

                // Check product size availability
                var productSize = await repositoryManager.ProductSizeRepository
                    .GetProductSizeByProductAndSize(orderItemDto.ProductId, orderItemDto.SizeId, cancellationToken);

                if (productSize == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "This size is not available for the selected product." };
                }

                if (productSize.Quantity < orderItemDto.Quantity)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = $"Not enough items in stock. Available quantity: {productSize.Quantity}" };
                }

                // Calculate item total price
                decimal itemTotalPrice = product.Price * orderItemDto.Quantity;

                // Create order item
                var orderItem = new OrderItem
                {
                    OrderId = orderItemDto.OrderId,
                    ProductId = orderItemDto.ProductId,
                    SizeId = orderItemDto.SizeId,
                    Quantity = orderItemDto.Quantity,
                    CreatedAt = DateTime.UtcNow
                };

                // Update product size quantity
                productSize.Quantity -= orderItemDto.Quantity;

                // Update order total price
                order.TotalPrice += itemTotalPrice;
                
                // Save all changes
                repositoryManager.OrderItemRepository.Create(orderItem);
                repositoryManager.ProductSizeRepository.Update(productSize);
                repositoryManager.OrderRepository.Update(order);
                
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto 
                { 
                    IsSuccess = true, 
                    Message = $"Order item created successfully. Total order price: {order.TotalPrice:C}" 
                };
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
