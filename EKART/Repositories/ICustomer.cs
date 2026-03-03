using EKART.DTOs;

namespace EKART.Repositories
{
    public interface ICustomer
    {
        Task<string> CreateCustomer(CustomerDto customerDto);
        Task<List<CustomerDto>> GetAllCustomers();
        Task<List<CustomerDto>> GetCustomersByCity(string city);
        Task<bool> UpdateCustomerName(int customerId, string contactName);
        Task<bool> UpdateRegionOfCustomer(int customerId,string region);


    }
}
