using EKART.Models;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Repositories
{
    public interface IProduct
    {
        Task<string> CreateProduct(ProductDto product);
        Task<List<ProductDto>> GetAllProducts();
        Task<bool> UpdateProduct(int productId,ProductDto product);
        Task<bool> PatchProduct(int productId, ProductDto product);
        Task<List<ProductDto>> GetDiscontinuedProducts();
        Task<List<ProductDto>> GetProductByCategoryName(string categoryName);
        Task<List<ProductDto>> GetProductBySuppplier(string companyName);
        Task<List<ProductDto>> ProdusctsInStock();
        Task<List<ProductDto>> UnitsInOrder();
        Task<List<(string,int)>> OutOfStock();
    }
}
