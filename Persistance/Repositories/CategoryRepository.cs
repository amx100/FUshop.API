using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Common;

namespace Persistance.Repositories;

public class CategoryRepository(DataContext dataContext) : RepositoryBase<Category>(dataContext), ICategoryRepository
{
    public void CreateCategory(Category category, CancellationToken cancellationToken = default) => Create(category);
    public void DeleteCategory(Category category, CancellationToken cancellationToken = default) => Delete(category);
    public void UpdateCategory(Category category, CancellationToken cancellationToken = default) => Update(category);
    public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken = default) => await FindAll().ToListAsync(cancellationToken);
    public async Task<Category> GetById(int categoryId, CancellationToken cancellationToken = default) => await FindByCondition(c => c.CategoryId == categoryId).FirstOrDefaultAsync(cancellationToken);
}
