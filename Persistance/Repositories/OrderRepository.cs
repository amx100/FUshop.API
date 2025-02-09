using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Common;

namespace Persistance.Repositories;

public class OrderRepository(DataContext dataContext) : RepositoryBase<Order>(dataContext), IOrderRepository
{
    public void CreateOrder(Order order, CancellationToken cancellationToken = default) => Create(order);
    public void DeleteOrder(Order order, CancellationToken cancellationToken = default) => Delete(order);
    public void UpdateOrder(Order order, CancellationToken cancellationToken = default) => Update(order);
    public async Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken = default) => await FindByCondition(o => o.OrderId == orderId).FirstOrDefaultAsync(cancellationToken);
}
