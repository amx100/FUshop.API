using Domain.Entities;
using MyProperty.API.Core.Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrderItemRepository : IRepositoryBase<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetAll(CancellationToken cancellationToken = default);
        Task<OrderItem> GetById(int orderItemId, CancellationToken cancellationToken = default);
        void CreateOrderItem(OrderItem orderItem, CancellationToken cancellationToken = default);
        void DeleteOrderItem(OrderItem orderItem, CancellationToken cancellationToken = default);
        void UpdateOrderItem(OrderItem orderItem, CancellationToken cancellationToken = default);
    }
}
