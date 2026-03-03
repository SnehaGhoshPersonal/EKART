using System.Linq;
using EKART.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repositories
{
    public class ProductRepository:IProduct
    {
        private readonly EKARTContext _context;
        public ProductRepository(EKARTContext context)
        {
            _context = context;
        }
        public async Task<string> CreateProduct(ProductDto productDto)
        {
            Product product = new Product
            {
                ProductName = productDto.ProductName,
                SupplierId = productDto.SupplierId,
                CategoryId = productDto.CategoryId,
                QuantityPerUnit = productDto.QuantityPerUnit,
                UnitPrice = productDto.UnitPrice,
                UnitInStock = productDto.UnitInStock,
                UnitsOnOrder = productDto.UnitsOnOrder,
                ReorderLevel = productDto.ReorderLevel,
                Discontinued = productDto.Discontinued
            };
            Console.WriteLine($"ProductId before save: {product.ProductId}");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return  "Record Added Successfully!";
        }
        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            List<ProductDto> productsDto = new List<ProductDto>();
            foreach(var product in products){
                var productDto = new ProductDto
                {
                    ProductId=product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued
                };
                productsDto.Add(productDto);
            }
            return productsDto;
        }
        public async Task<bool> UpdateProduct(int productId, ProductDto productDto)
        {
            var toUpdate= await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if(toUpdate==null) return false;
            var toUpdateDto = new ProductDto
            {
                ProductId = productId,
                ProductName = productDto.ProductName,
                SupplierId = productDto.SupplierId,
                CategoryId = productDto.CategoryId,
                QuantityPerUnit = productDto.QuantityPerUnit,
                UnitPrice = productDto.UnitPrice,
                UnitInStock = productDto.UnitInStock,
                UnitsOnOrder = productDto.UnitsOnOrder,
                ReorderLevel = productDto.ReorderLevel,
                Discontinued = productDto.Discontinued
            };
            toUpdate.ProductId= productId;
            toUpdate.ProductName=toUpdateDto.ProductName;
            toUpdate.SupplierId= toUpdateDto.SupplierId;
            toUpdate.CategoryId= toUpdateDto.CategoryId;
            toUpdate.QuantityPerUnit= toUpdateDto.QuantityPerUnit;
            toUpdate.UnitPrice= toUpdateDto.UnitPrice;
            toUpdate.UnitInStock=toUpdateDto.UnitInStock;
            toUpdate.UnitsOnOrder= toUpdateDto.UnitsOnOrder;
            toUpdate.ReorderLevel= toUpdateDto.ReorderLevel;
            toUpdate.Discontinued= toUpdateDto.Discontinued;
            await _context.SaveChangesAsync();
            return true; 
            
        }
        public async Task<bool> PatchProduct(int productId, ProductDto productDto)
        {
            var toUpdate = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (toUpdate == null) return false;
            var toUpdateDto = new ProductDto
            {
                ProductId = productId,
                ProductName = productDto.ProductName,
                SupplierId = productDto.SupplierId,
                CategoryId = productDto.CategoryId,
                QuantityPerUnit = productDto.QuantityPerUnit,
                UnitPrice = productDto.UnitPrice,
                UnitInStock = productDto.UnitInStock,
                UnitsOnOrder = productDto.UnitsOnOrder,
                ReorderLevel = productDto.ReorderLevel,
                Discontinued = productDto.Discontinued
            };
            toUpdate.ProductId = productId;
            toUpdate.ProductName = toUpdateDto.ProductName;
            toUpdate.SupplierId = toUpdateDto.SupplierId;
            toUpdate.CategoryId = toUpdateDto.CategoryId;
            toUpdate.QuantityPerUnit = toUpdateDto.QuantityPerUnit;
            toUpdate.UnitPrice = toUpdateDto.UnitPrice;
            toUpdate.UnitInStock = toUpdateDto.UnitInStock;
            toUpdate.UnitsOnOrder = toUpdateDto.UnitsOnOrder;
            toUpdate.ReorderLevel = toUpdateDto.ReorderLevel;
            toUpdate.Discontinued = toUpdateDto.Discontinued;
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<List<ProductDto>> GetDiscontinuedProducts()
        {
            var discountedProducts=await _context.Products.Where(p=>p.Discontinued==true).ToListAsync();
            var discountedProductsDto = new List < ProductDto > ();
            foreach (var product in discountedProducts)
            {
                var p = new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued
                };
                discountedProductsDto.Add(p);
            }
            return discountedProductsDto;
        }
        
        public async Task<List<ProductDto>> GetProductByCategoryName(string categoryName)
        {
            var categoryId = (_context.Categories.FirstOrDefault(c => c.CategoryName.Equals(categoryName))).CategoryId;
            var productList = await _context.Products.Where(p => p.CategoryId.Equals(categoryId)).ToListAsync();
            var productDtoList = new List<ProductDto>();
            foreach (var product in productList)
            {
                var p = new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued
                };
                productDtoList.Add(p);
            }
            return productDtoList;
        }
        public async Task<List<ProductDto>> GetProductBySuppplier(string companyName)
        {
            var supplierId = (_context.Suppliers.FirstOrDefault(s => s.CompanyName.Equals(companyName))).SupplierId;
            var productList =  await _context.Products.Where(p => p.SupplierId.Equals(supplierId)).ToListAsync();
            var productDtoList = new List<ProductDto>();
            foreach (var product in productList)
            {
                var p = new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued
                };
                productDtoList.Add(p);
            }
            return productDtoList;
        }
        public async Task<List<ProductDto>> ProdusctsInStock()
        {
            var productList = await _context.Products.Where(p => p.UnitInStock > 0).ToListAsync();
            var productDtoList = new List<ProductDto>();
            foreach (var product in productList)
            {
                var p = new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued
                };
                productDtoList.Add(p);
            }
            return productDtoList;
        }
        public async Task<List<ProductDto>> UnitsInOrder()
        {
            var productList = await _context.Products.Where(p => p.UnitsOnOrder > 0).ToListAsync();
            var productDtoList = new List<ProductDto>();
            foreach (var product in productList)
            {
                var p = new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued
                };
                productDtoList.Add(p);
            }
            return productDtoList;
        }
        public async Task<List<(string,int)>> OutOfStock()
        {
            var productList = await _context.Products.Where(p => p.UnitInStock ==0).ToListAsync();
            var outOfStockList = new List<(string, int)>();
            foreach (var product in productList)
            {
                outOfStockList.Add((product.ProductName, (int)product.UnitInStock));
            }
            return outOfStockList; ;
        }
    }
}
