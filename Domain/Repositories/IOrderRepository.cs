using Domain.Entities;
using MyProperty.API.Core.Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IOrderRepository : IRepositoryBase<Order>
{
    Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken = default);
    Task<Order> GetById(int orderId, CancellationToken cancellationToken = default);
    void CreateOrder(Order order, CancellationToken cancellationToken = default);
    void DeleteOrder(Order order, CancellationToken cancellationToken = default);
    void UpdateOrder(Order order, CancellationToken cancellationToken = default);
}