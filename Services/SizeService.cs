using Contract.DataTransferObject;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Services
{
    public class SizeService(IRepositoryManager repositoryManager) : ISizeService
    {
        public async Task<GeneralResponseDto> Create(SizeCreateDto sizeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var size = new Size
                {
                    Name = sizeDto.Name,
                    CreatedAt = DateTime.UtcNow
                };

                repositoryManager.SizeRepository.Create(size);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Size created successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error creating size: {ex.Message}" };
            }
        }

        public async Task<IEnumerable<SizeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var sizes = await repositoryManager.SizeRepository.GetAll(cancellationToken);
            var sizeDtos = sizes.Select(s => new SizeDto
            {
                SizeId = s.SizeId,
                Name = s.Name,
                DisplayOrder = s.DisplayOrder,

            });
            return sizeDtos;
        }

        public async Task<GeneralResponseDto> GetById(int sizeId, CancellationToken cancellationToken = default)
        {
            var size = await repositoryManager.SizeRepository.GetById(sizeId, cancellationToken);
            if (size == null)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
            }

            var sizeDto = new SizeDto
            {
                SizeId = size.SizeId,
                Name = size.Name,
                DisplayOrder = size.DisplayOrder
            };

            return new GeneralResponseDto
            {
                Data = sizeDto,
                IsSuccess = true,
                Message = "Size found successfully."
            };
        }

        public async Task<GeneralResponseDto> Update(int sizeId, SizeUpdateDto sizeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingSize = await repositoryManager.SizeRepository.GetById(sizeId, cancellationToken);
                if (existingSize == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }

                existingSize.Name = sizeDto.Name;
           
                repositoryManager.SizeRepository.Update(existingSize);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Size updated successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error updating size: {ex.Message}" };
            }
        }

        public async Task<GeneralResponseDto> Delete(int sizeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var size = await repositoryManager.SizeRepository.GetById(sizeId, cancellationToken);
                if (size == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Size not found." };
                }

                repositoryManager.SizeRepository.Delete(size);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto { IsSuccess = true, Message = "Size deleted successfully." };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto { IsSuccess = false, Message = $"Error deleting size: {ex.Message}" };
            }
        }
    }
}
