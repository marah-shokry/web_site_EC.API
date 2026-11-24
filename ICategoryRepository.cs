using Domain.Entities;
using Domain.Interface;
namespace Domain.Interface
{
    public interface ICategoryRepository 
    {
        Task<Category?> GetByIdAsync(int id);
        Task<IReadOnlyList<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
