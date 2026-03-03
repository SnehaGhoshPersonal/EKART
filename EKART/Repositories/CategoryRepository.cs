using System.Diagnostics.Metrics;
using EKART.DTOs;
using EKART.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EKART.Repositories
{
    public class CategoryRepository:ICategory
    {
        private readonly EKARTContext _context;
        public CategoryRepository(EKARTContext context)
        {
            _context = context;
        }
        
        public async Task<bool> CreateCategory(CategoryDto categoryDto)
        {
            Category category = new Category
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description,
                Picture = categoryDto.Picture
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            List<CategoryDto> categoriesDto=new List<CategoryDto>();
            foreach(var category in categories)
            {
                var categoryDto = new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    Picture = category.Picture
                };
                categoriesDto.Add(categoryDto);
            }
            return categoriesDto;
        }
        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == categoryId);
            if (category == null) return null ;
            var categoryDto = new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    Picture = category.Picture
                };
                
            
            return categoryDto;
        }
        public async Task<bool> UpdateCategoryDescription(int categoryId, string description)
        {
            var toUpdate= await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == categoryId);
            if (toUpdate == null) return false;
            var toUpdateDto = new CategoryDto
            {
                Description = description
            };
            toUpdate.Description = description;
            
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateCategory(int categoryId, CategoryDto categoryDto)
        {
            var toUpdate = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == categoryId);
            if (toUpdate == null) return false;
            var toUpdateDto = new CategoryDto
            {
                CategoryId = categoryId,
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description,
                Picture = categoryDto.Picture
            };
            toUpdate.CategoryId = categoryId;
            toUpdate.CategoryName = toUpdateDto.CategoryName;
            toUpdate.Description = toUpdateDto.Description;
            toUpdate.Picture = toUpdateDto.Picture;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
