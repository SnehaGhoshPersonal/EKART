using EKART.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EKART.DTOs;
using EKART.Repositories;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplier _supplier;
        public SupplierController(ISupplier supplier)
        {
            _supplier = supplier;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> Createsuppliers(SupplierDto supplierDto)
        {
            return Ok(await _supplier.CreateSupplier(supplierDto));
        }
        [HttpGet]
        public async Task<List<SupplierDto>> GetAllSupplier()
        {
            return await _supplier.GetAllSupplier();
        }
        [HttpPatch("{id}/{address}/{city}/{postalCode}/{country}/{region}")]
        public async Task<string> UpdateSupplier(int id, string address, string city, string postalCode, string country,string region)
        {
            if (await _supplier.UpdateSupplier(id, address, city,postalCode, country,region)) return "Updated successfully";
            return "Something went wrong!";
        }
        [HttpGet("{country}")]
        public async Task<List<SupplierDto>> GetSupplierByCountry(string country) 
        {
            return await _supplier.GetSupplierByCountry(country);
        }
    }
}
