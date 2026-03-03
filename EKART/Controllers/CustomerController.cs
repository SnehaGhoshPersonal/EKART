using System.Diagnostics.Metrics;
using System.Net;
using EKART.DTOs;
using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> CreateCustomer(CustomerDto customerDto)
        {
            return Ok(await _customer.CreateCustomer(customerDto));

        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            return Ok(await _customer.GetAllCustomers());
        }
        [HttpGet("City/{city}")]
        public async Task<List<CustomerDto>> GetCustomersByCity(string city)
        {
            return await _customer.GetCustomersByCity(city);
        }
        [HttpPut("Edit/{customerId}/{contactName}")]
        public async Task<ActionResult> UpdateCustomerName(int customerId, string contactName)
        {
            bool isUpdated = await _customer.UpdateCustomerName(customerId, contactName);

            if (isUpdated)
                return NoContent();

            return NotFound(new { message = "Customer not found or update failed." });
        }
        [HttpPatch("Edit/{customerId}/{region}")]
        public async Task<ActionResult> UpdateRegionOfCustomer(int customerId, string region)
        {
            bool isUpdated = await _customer.UpdateRegionOfCustomer(customerId, region);

            if (isUpdated)
                return NoContent();

            return NotFound(new { message = "Customer not found or update failed." });
        }
    }
}
