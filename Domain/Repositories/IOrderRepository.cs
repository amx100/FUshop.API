﻿using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IOrderRepository : IRepositoryBase<Order>
{
    Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken = default);
    Task<Order> GetById(int orderId, CancellationToken cancellationToken = default);
    void CreateOrder(Order order, CancellationToken cancellationToken = default);
    void DeleteOrder(Order order, CancellationToken cancellationToken = default);
    void UpdateOrder(Order order, CancellationToken cancellationToken = default);
}