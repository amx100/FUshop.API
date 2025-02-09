using Contract.DataTransferObject;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Services
{
    public class CategoryService(IRepositoryManager repositoryManager) : ICategoryService
    {
        public async Task<GeneralResponseDto> Create(CategoryCreateDto categoryDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryDto.Name,
                    ImageUrl = categoryDto.ImageUrl,
                    Slug = categoryDto.Slug,
                    CreatedAt = DateTime.UtcNow
                };

                repositoryManager.CategoryRepository.Create(category);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Category created successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error creating category: {ex.Message}" };
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var categories = await repositoryManager.CategoryRepository.GetAll(cancellationToken);
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                Slug = c.Slug
            });
            return categoryDtos;
        }

        public async Task<GeneralResponseDto> GetById(int categoryId, CancellationToken cancellationToken = default)
        {
            var category = await repositoryManager.CategoryRepository.GetById(categoryId, cancellationToken);
            if (category == null)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = "Category not found." };
            }

            var categoryDto = new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                Slug = category.Slug
            };

            return new GeneralResponseDto
            {
                Data = categoryDto,
                IsSuccess = true,
                Message = "Category found successfully."
            };
        }

        public async Task<GeneralResponseDto> Update(int categoryId, CategoryUpdateDto categoryDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingCategory = await repositoryManager.CategoryRepository.GetById(categoryId, cancellationToken);
                if (existingCategory == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Category not found." };
                }

                existingCategory.Name = categoryDto.Name;
                existingCategory.ImageUrl = categoryDto.ImageUrl;
                existingCategory.Slug = categoryDto.Slug;

                repositoryManager.CategoryRepository.Update(existingCategory);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Category updated successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error updating category: {ex.Message}" };
            }
        }

        public async Task<GeneralResponseDto> Delete(int categoryId, CancellationToken cancellationToken = default)
        {
            try
            {
                var category = await repositoryManager.CategoryRepository.GetById(categoryId, cancellationToken);
                if (category == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Category not found." };
                }

                repositoryManager.CategoryRepository.Delete(category);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Category deleted successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error deleting category: {ex.Message}" };
            }
        }
    }
}
