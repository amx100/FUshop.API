using Domain.Entities;
using Domain.Repositories;
using MyProperty.API.Infrastructure.Persistence.Persistence.Repositories.Common;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class OrderRepository(DataContext dataContext) : RepositoryBase<Order>(dataContext), IOrderRepository
{
    public void CreateOrder(Order order, CancellationToken cancellationToken = default) => Create(order);
    public void DeleteOrder(Order order, CancellationToken cancellationToken = default) => Delete(order);
    public void UpdateOrder(Order order, CancellationToken cancellationToken = default) => Update(order);
    public async Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken = default) => await FindByCondition(o => o.Id == orderId).FirstOrDefaultAsync(cancellationToken);
}
