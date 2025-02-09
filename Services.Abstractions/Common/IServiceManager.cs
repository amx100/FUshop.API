namespace Services.Abstractions.Common
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IProductService ProductService { get; }
        IProductSizeService ProductSizeService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        IOrderItemService OrderItemService { get; }
        ISizeService SizeService { get; }

    }
}