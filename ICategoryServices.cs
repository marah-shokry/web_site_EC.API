using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Category;
namespace Application.Interface
{
    public interface ICategoryServices
    {
        Task<CategoryDto?>GetByIdAsync(int id);   
        Task<IReadOnlyList<CategoryDto>>GetAllAsync();

        Task<CategoryDto> CreateAsync(CreateCategoryDto createcategoryDto);

        Task<bool>UpdateAsync(int id, UpdateCategoryDto updateCategoryDto);

        Task<bool> DeleteAsync(int id);


    }
}
