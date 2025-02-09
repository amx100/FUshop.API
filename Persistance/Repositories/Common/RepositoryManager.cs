using Domain.Repositories;
using Domain.Repositories.Common;

namespace Persistance.Repositories.Common
{
    public class RepositoryManager(DataContext dbContext) : IRepositoryManager
    {
        private readonly Lazy<IAccountRepository> _lazyAccountRepository = new(() => new AccountRepository(dbContext));

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork = new(() => new UnitOfWork(dbContext));

        private readonly Lazy<IProductRepository> _lazyProductRepository = new(() => new ProductRepository(dbContext));

        private readonly Lazy<IProductSizeRepository> _lazyProductSizeRepository = new(() => new ProductSizeRepository(dbContext));

        private readonly Lazy<ICategoryRepository> _lazyCategoryRepository = new(() => new CategoryRepository(dbContext));

        private readonly Lazy<IOrderRepository> _lazyOrderRepository = new(() => new OrderRepository(dbContext));

        private readonly Lazy<IOrderItemRepository> _lazyOrderItemRepository = new(() => new OrderItemRepository(dbContext));

        private readonly Lazy<ISizeRepository> _lazySizeRepository = new(() => new SizeRepository(dbContext));





        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IProductRepository ProductRepository => _lazyProductRepository.Value;
        public IProductSizeRepository ProductSizeRepository => _lazyProductSizeRepository.Value;
        public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;
        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;
        public IOrderItemRepository OrderItemRepository => _lazyOrderItemRepository.Value;
        public ISizeRepository SizeRepository => _lazySizeRepository.Value;
    }
}