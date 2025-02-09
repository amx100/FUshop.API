using Contract.DataTransferObject;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Services
{
    public class ProductService(IRepositoryManager repositoryManager) : IProductService
    {
        public async Task<GeneralResponseDto> Create(ProductCreateDto productDto, CancellationToken cancellationToken = default)
        {
            try
            {
                // Check if category exists
                var category = await repositoryManager.CategoryRepository.GetById(productDto.CategoryId, cancellationToken);
                if (category == null)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Category not found."
                    };
                }

                // Create new product
                var product = new Product
                {
                    Title = productDto.Title,
                    Slug = productDto.Slug,
                    ImageUrl = productDto.ImageUrl,
                    Price = productDto.Price,
                    HeroImage = productDto.HeroImage,
                    CategoryId = productDto.CategoryId,
                    CreatedAt = DateTime.UtcNow
                };

                repositoryManager.ProductRepository.Create(product);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { Message = "Product created successfully.", IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

     
        public async Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var products = await repositoryManager.ProductRepository.GetAll(cancellationToken);

            var productDtos = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Title = p.Title,
                Slug = p.Slug,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                HeroImage = p.HeroImage,
                CategoryId = p.CategoryId,
               // CategoryName = p.Category.Name
            });

            return productDtos;
        }

        public async Task<GeneralResponseDto> GetById(int productId, CancellationToken cancellationToken = default)
        {
            var product = await repositoryManager.ProductRepository.GetById(productId, cancellationToken);

            if (product == null)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = $"Product with ID {product.ProductId} not found."
                    // PropertyId is omitted here
                };
            }

            var productDto = new ProductDto
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Slug = product.Slug,              
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                HeroImage = product.HeroImage,
                CategoryId = product.CategoryId
            };
            return new GeneralResponseDto
            {
                Data = productDto,
                IsSuccess = true,
                Message = "Property found successfully.",
            };
        }

        public async Task<GeneralResponseDto>Delete(int productId, CancellationToken cancellationToken = default)
        {
            try
            {
                var product = await repositoryManager.ProductRepository.GetById(productId, cancellationToken);
                if (product == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product not found." };
                }

                repositoryManager.ProductRepository.Delete(product);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Product deleted successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error deleting product: {ex.Message}" };
            }
        }

        public async Task<GeneralResponseDto> Update(int productId, ProductUpdateDto productDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingProduct = await repositoryManager.ProductRepository.GetById(productId, cancellationToken);
                if (existingProduct == null)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Product not found."
                    };
                }

                var category = await repositoryManager.CategoryRepository.GetById(productDto.CategoryId, cancellationToken);
                if (category == null)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Category not found."
                    };
                }

                existingProduct.Title = productDto.Title;
                existingProduct.Slug = productDto.Slug;
                existingProduct.ImageUrl = productDto.ImageUrl;
                existingProduct.Price = productDto.Price;
                existingProduct.HeroImage = productDto.HeroImage;
                existingProduct.CategoryId = productDto.CategoryId;

                repositoryManager.ProductRepository.Update(existingProduct);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Product updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = $"Error updating product: {ex.Message}"
                };
            }
        }

        
    }

}
