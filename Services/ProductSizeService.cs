using Contract.DataTransferObject;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Services
{
    public class ProductSizeService(IRepositoryManager repositoryManager) : IProductSizeService
    {
        public async Task<GeneralResponseDto> Create(ProductSizeCreateDto productSizeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                // Provera da li proizvod postoji
                var product = await repositoryManager.ProductRepository.GetById(productSizeDto.ProductId, cancellationToken);
                if (product == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product not found." };
                }

                // Provera da li veličina postoji
                var size = await repositoryManager.SizeRepository.GetById(productSizeDto.SizeId, cancellationToken);
                if (size == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }

                var productSize = new ProductSize
                {
                    ProductId = productSizeDto.ProductId,
                    SizeId = productSizeDto.SizeId,
                    Quantity = productSizeDto.Quantity,
                    CreatedAt = DateTime.UtcNow
                };

                repositoryManager.ProductSizeRepository.Create(productSize);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Product size created successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<IEnumerable<ProductSizeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var productSizes = await repositoryManager.ProductSizeRepository.GetAll(cancellationToken);
            var productSizeDtos = productSizes.Select(ps => new ProductSizeDto
            {
                ProductSizeId = ps.ProductSizeId,
                ProductId = ps.ProductId,
                SizeId = ps.SizeId,
                Quantity = ps.Quantity
                // Dodajte ostala svojstva ako je potrebno
            });
            return productSizeDtos;
        }

        public async Task<GeneralResponseDto> GetById(int productSizeId, CancellationToken cancellationToken = default)
        {
            var productSize = await repositoryManager.ProductSizeRepository.GetById(productSizeId, cancellationToken);
            if (productSize == null)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = "Product size not found." };
            }

            var productSizeDto = new ProductSizeDto
            {
                ProductSizeId = productSize.ProductSizeId,
                ProductId = productSize.ProductId,
                SizeId = productSize.SizeId,
                Quantity = productSize.Quantity
            };

            return new GeneralResponseDto
            {
                Data = productSizeDto,
                IsSuccess = true,
                Message = "Product size found successfully."
            };
        }

        public async Task<GeneralResponseDto> Update(int productSizeId, ProductSizeUpdateDto productSizeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingProductSize = await repositoryManager.ProductSizeRepository.GetById(productSizeId, cancellationToken);
                if (existingProductSize == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product size not found." };
                }

                // Provera validnosti povezanih entiteta
                var product = await repositoryManager.ProductRepository.GetById(productSizeDto.ProductId, cancellationToken);
                if (product == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product not found." };
                }

                var size = await repositoryManager.SizeRepository.GetById(productSizeDto.SizeId, cancellationToken);
                if (size == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }

                existingProductSize.ProductId = productSizeDto.ProductId;
                existingProductSize.SizeId = productSizeDto.SizeId;
                existingProductSize.Quantity = productSizeDto.Quantity;

                repositoryManager.ProductSizeRepository.Update(existingProductSize);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Product size updated successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error updating product size: {ex.Message}" };
            }
        }

        public async Task<GeneralResponseDto> Delete(int productSizeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var productSize = await repositoryManager.ProductSizeRepository.GetById(productSizeId, cancellationToken);
                if (productSize == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Product size not found." };
                }

                repositoryManager.ProductSizeRepository.Delete(productSize);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Product size deleted successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error deleting product size: {ex.Message}" };
            }
        }
    }
}
