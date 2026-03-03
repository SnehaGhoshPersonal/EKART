using EKART.DTOs;
using EKART.Models;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repositories
{
    public class CustomerRepository:ICustomer
    {
        private readonly EKARTContext _context;
        public CustomerRepository(EKARTContext context)
        { 
            _context = context;
        }
        public async Task<string> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerId = customerDto.CustomerId,
                    CompanyName = customerDto.CompanyName,
                    ContactName = customerDto.ContactName,
                    ContactTitle = customerDto.ContactTitle,
                    Address = customerDto.Address,
                    City = customerDto.City,
                    Region = customerDto.Region,
                    PostalCode = customerDto.PostalCode,
                    Country = customerDto.Country,
                    Phone = customerDto.Phone,
                    Fax = customerDto.Fax
                };
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return "Record Added Successfully";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                var customerDtos = new List<CustomerDto>();
                foreach (var cutomer in customers)
                {
                    var customerDto = new CustomerDto
                    {
                        CustomerId = cutomer.CustomerId,
                        CompanyName = cutomer.CompanyName,
                        ContactName = cutomer.ContactName,
                        ContactTitle = cutomer.ContactTitle,
                        Address = cutomer.Address,
                        City = cutomer.City,
                        Region = cutomer.Region,
                        PostalCode = cutomer.PostalCode,
                        Country = cutomer.Country,
                        Phone = cutomer.Phone,
                        Fax = cutomer.Fax
                    };
                    customerDtos.Add(customerDto);
                }
                return customerDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CustomerDto>();
            }
        }
        public async Task<List<CustomerDto>> GetCustomersByCity(string city)
        {
            try
            {
                var customers = await _context.Customers.Where(c => c.City.Equals(city,StringComparison.OrdinalIgnoreCase)).ToListAsync();
                var customerDtos = new List<CustomerDto>();
                foreach (var cutomer in customers)
                {
                    var customerDto = new CustomerDto
                    {
                        CustomerId = cutomer.CustomerId,
                        CompanyName = cutomer.CompanyName,
                        ContactName = cutomer.ContactName,
                        ContactTitle = cutomer.ContactTitle,
                        Address = cutomer.Address,
                        City = cutomer.City,
                        Region = cutomer.Region,
                        PostalCode = cutomer.PostalCode,
                        Country = cutomer.Country,
                        Phone = cutomer.Phone,
                        Fax = cutomer.Fax
                    };
                    customerDtos.Add(customerDto);
                }
                if(customerDtos!=null)return customerDtos;
                else { Console.WriteLine("No customer from this city");return new List<CustomerDto> { new CustomerDto() }; }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CustomerDto>();
            }
        }
        public async Task<bool> UpdateCustomerName(int customerId,string contactName)
        {
            try
            {
                var toUpdate = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (toUpdate != null)
                {
                    toUpdate.ContactName = contactName;
                    return true;
                }
                else
                {
                    Console.WriteLine("Customer not found");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateRegionOfCustomer(int customerId,string region)
        {
            try
            {
                var toUpdate = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (toUpdate != null)
                {
                    toUpdate.Region = region;
                    return true;
                }
                else
                {
                    Console.WriteLine("Customer not found");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
