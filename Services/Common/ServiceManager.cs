global using Contract;
global using Microsoft.IdentityModel.Tokens;
global using Services.Abstractions;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
using Domain.Entities;
using Domain.Repositories.Common;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions.Common;


namespace Services.Common
{
    public class ServiceManager(
        IRepositoryManager repositoryManager,
        UserManager<Account> userManager,
        RoleManager<AccountRole> roleManager,
        ITokenService tokenService) : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService = new(() => new AccountService(repositoryManager, userManager, roleManager, tokenService));


        private readonly Lazy<IProductService> _lazyProductService = new(() => new ProductService(repositoryManager));

        private readonly Lazy<IProductSizeService> _lazyProductSizeService = new(() => new ProductSizeService(repositoryManager));
        private readonly Lazy<ICategoryService> _lazyCategoryService = new(() => new CategoryService(repositoryManager));
        private readonly Lazy<IOrderService> _lazyOrderService = new(() => new OrderService(repositoryManager));
        private readonly Lazy<IOrderItemService> _lazyOrderItemService = new(() => new OrderItemService(repositoryManager));
        private readonly Lazy<ISizeService> _lazySizeService = new(() => new SizeService(repositoryManager));


        public IAccountService AccountService => _lazyAccountService.Value;

        public IProductService ProductService => _lazyProductService.Value;

        public IProductSizeService ProductSizeService => _lazyProductSizeService.Value;

        public ICategoryService CategoryService => _lazyCategoryService.Value;

        public IOrderService OrderService => _lazyOrderService.Value;

        public IOrderItemService OrderItemService => _lazyOrderItemService.Value;

        public ISizeService SizeService => _lazySizeService.Value;
    }
}