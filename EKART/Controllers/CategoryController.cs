using System.Threading.Tasks;
using EKART.DTOs;
using EKART.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        
        [HttpPost]
        public async Task<string> CreateCategory(CategoryDto categoryDto)
        {
            if (await _category.CreateCategory(categoryDto))
                return "Record added Successfully!";
            return "Something went wrong";

        }
        [Authorize]
        [HttpGet]
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _category.GetAllCategories();
        }
        [HttpPatch("{categoryId}")]
        public async Task<string> UpdateCategoryDescription(int categoryId, string description)
        {
            if (await _category.UpdateCategoryDescription(categoryId, description)) return "Description is updated";
            else return "Something went wrong!";
        }
        [HttpPut("{categoryId}")]
        public async Task<string> UpdateCategory(int categoryId, CategoryDto categoryDto)
        {
            if (await _category.UpdateCategory(categoryId, categoryDto)) return "Category is updated";
            else return "Something went wrong!";
        }
        [HttpGet("{categoryId}")]
        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            return await _category.GetCategoryById(categoryId);
        }
    }
}
