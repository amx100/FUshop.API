using Contract.DataTransferObject;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Services
{
    public class OrderService(IRepositoryManager repositoryManager) : IOrderService
    {
        public async Task<GeneralResponseDto> Create(OrderCreateDto orderDto, CancellationToken cancellationToken = default)
        {
            try
            {
                // Kreiramo novu narudžbinu na osnovu podataka iz DTO-a
                var order = new Order
                {
                    Status = orderDto.Status,
                    Description = orderDto.Description,
                    AccountId = orderDto.AccountId,
                    Slug = orderDto.Slug,
                    TotalPrice = orderDto.TotalPrice,
                    CreatedAt = DateTime.UtcNow,
                    // Inicijalizujemo praznu kolekciju za stavke narudžbine
                    OrderItems = new List<OrderItem>()
                };

                repositoryManager.OrderRepository.Create(order);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Order created successfully."
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = $"Error creating order: {ex.Message}"
                };
            }
        }

        public async Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var orders = await repositoryManager.OrderRepository.GetAll(cancellationToken);
            var orderDtos = orders.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                Status = o.Status,
                Description = o.Description,
                AccountId = o.AccountId,
                Slug = o.Slug,
                TotalPrice = o.TotalPrice,
                // Opcionalno: Mapiranje OrderItems
            });
            return orderDtos;
        }

        public async Task<GeneralResponseDto> GetById(int orderId, CancellationToken cancellationToken = default)
        {
            var order = await repositoryManager.OrderRepository.GetById(orderId, cancellationToken);
            if (order == null)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = "Order not found." };
            }

            var orderDto = new OrderDto
            {
                OrderId = order.OrderId,
                Status = order.Status,
                Description = order.Description,
                AccountId = order.AccountId,
                Slug = order.Slug,
                TotalPrice = order.TotalPrice,
                // Opcionalno: Mapiranje OrderItems
            };

            return new GeneralResponseDto
            {
                Data = orderDto,
                IsSuccess = true,
                Message = "Order found successfully."
            };
        }

        public async Task<GeneralResponseDto> Update(int orderId, OrderUpdateDto orderDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingOrder = await repositoryManager.OrderRepository.GetById(orderId, cancellationToken);
                if (existingOrder == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Order not found." };
                }

                existingOrder.Status = orderDto.Status;
                existingOrder.Description = orderDto.Description;
                existingOrder.TotalPrice = orderDto.TotalPrice;
                // Opcionalno: Ažurirajte OrderItems ako je potrebno

                repositoryManager.OrderRepository.Update(existingOrder);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Order updated successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error updating order: {ex.Message}" };
            }
        }

        public async Task<GeneralResponseDto> Delete(int orderId, CancellationToken cancellationToken = default)
        {
            try
            {
                var order = await repositoryManager.OrderRepository.GetById(orderId, cancellationToken);
                if (order == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Order not found." };
                }

                repositoryManager.OrderRepository.Delete(order);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Order deleted successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error deleting order: {ex.Message}" };
            }
        }
    }
}
