using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Application.Dtos.Category;
using Application.Interface;
using Domain.Interface;
using System.Linq;
using Domain.Entities;
using Application.Services;

namespace Application.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _categories;
        private readonly IProductRepository _products;


        public CategoryService(ICategoryRepository categories , IProductRepository products)
        {
            _categories = categories;
            _products = products;

        }

        private CategoryDto ToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createcategoryDto)
        {
            if(string.IsNullOrWhiteSpace(createcategoryDto.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            var category = new Category
            {
                Name = createcategoryDto.Name.Trim(),
                Description = createcategoryDto.Description
            };

            await _categories.AddAsync(category);
            return ToDto(category);

        }

        public  async Task<bool> DeleteAsync(int id)
        {
            var category = await _categories.GetByIdAsync(id);
            if(category is null)
            {
                return false;
            }
            var products = await _products.GetByCategoryAsync(id);
            if(products.Any())
            {
                throw new InvalidOperationException("Cannot delete category with associated products.");
            }
            await _categories.DeleteAsync(category);
            return true;
        }

        public async Task<IReadOnlyList<CategoryDto>> GetAllAsync()
        {
            var categories = await _categories.GetAllAsync();
            return categories.Select(ToDto).ToList();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categories.GetByIdAsync(id);
            return category is null ? null:ToDto(category);
        }

        public async Task<bool> UpdateAsync(int id,UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categories.GetByIdAsync(id);
            if (category is null)
            {
                return false;
            }
            if(string.IsNullOrWhiteSpace(updateCategoryDto.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }

            category.Name = updateCategoryDto.Name.Trim();
            category.Description = updateCategoryDto.Description;
            await _categories.UpdateAsync(category);
            return true;
        }
    }
}
