using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
 using System.Threading.Tasks;
using Domain.Interface;
namespace Domain.Interface
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<IReadOnlyList<Product>> GetByCategoryAsync(int categoryId);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
