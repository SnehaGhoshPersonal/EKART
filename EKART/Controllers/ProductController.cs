using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _product.GetAllProducts());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            var result = await _product.CreateProduct(productDto);
            return Ok(new { message = result });
        }

        [HttpPut("{productId}")]
        public async Task<string> UpdateProduct(int productId, ProductDto productDto)
        {
            if (await _product.UpdateProduct(productId, productDto)) return "Updated successfully!";
            return "Something went wrong";
        }
        [HttpPatch("{productId}")]
        public async Task<string> PatchProduct(int productId, ProductDto productDto)
        {
            if (await _product.PatchProduct(productId, productDto)) return "Updated successfully!";
            return "Something went wrong";
        }
        [HttpGet("Discontinued")]
        public async Task<List<ProductDto>> GetDiscontinuedProducts()
        {
            return await _product.GetDiscontinuedProducts();
        }
        [HttpGet("ProductName")]
        public async Task<List<ProductDto>> GetProductByCategoryName(string productName)
        {
            return await _product.GetProductByCategoryName(productName);
        }
        [HttpGet("{companyName}")]
        public async Task<List<ProductDto>> GetProductBySuppplier(string companyName)
        {
            return await _product.GetProductBySuppplier(companyName);
        }
        [HttpGet("Products in Stock")]
        public async Task<List<ProductDto>> ProdusctsInStock()
        {
            return await _product.ProdusctsInStock();
        }
        [HttpGet("Products in Order")]
        public async Task<List<ProductDto>> UnitsInOrder()
        {
            return await _product.UnitsInOrder();
        }
        [HttpGet("Out of Stock Products")]
        public async Task<List<(string, int)>> OutOfStock()
        {
            return await _product.OutOfStock();
        }
    }
}
    