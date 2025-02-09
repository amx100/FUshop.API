using Contract;
using Contract.DataTransferObject;

namespace Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll(CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> GetById(int categoryId, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Create(CategoryCreateDto categoryDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Update(int categoryId, CategoryUpdateDto categoryDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> Delete(int categoryId, CancellationToken cancellationToken = default);
    }
}
