using EKART.DTOs;

namespace EKART.Repositories
{
    public interface ICategory
    {
        Task<bool> CreateCategory(CategoryDto category);
        Task<List<CategoryDto>> GetAllCategories();
        Task<bool> UpdateCategoryDescription(int categoryId, string description);
        Task<bool> UpdateCategory(int categoryId, CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryById(int categoryId);
    }
}
