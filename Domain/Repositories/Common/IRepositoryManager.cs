using Domain.Repositories;

namespace MyProperty.API.Core.Domain.Repositories.Common
{
	public interface IRepositoryManager
    {
       
        IAccountRepository AccountRepository { get; }

        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductSizeRepository ProductSizeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        ISizeRepository SizeRepository { get; }
       

        IUnitOfWork UnitOfWork { get; }
    }
}