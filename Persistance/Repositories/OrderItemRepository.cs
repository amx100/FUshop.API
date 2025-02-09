using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Common;

namespace Persistance.Repositories;

public class OrderItemRepository(DataContext dataContext) : RepositoryBase<OrderItem>(dataContext), IOrderItemRepository
{
    public void CreateOrderItem(OrderItem orderItem, CancellationToken cancellationToken = default) => Create(orderItem);
    public void DeleteOrderItem(OrderItem orderItem, CancellationToken cancellationToken = default) => Delete(orderItem);
    public void UpdateOrderItem(OrderItem orderItem, CancellationToken cancellationToken = default) => Update(orderItem);
    public async Task<IEnumerable<OrderItem>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<OrderItem> GetById(int orderItemId, CancellationToken cancellationToken = default) => await FindByCondition(oi => oi.OrderId == orderItemId).FirstOrDefaultAsync(cancellationToken);
}
