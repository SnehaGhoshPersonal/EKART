using EKART.DTOs;

namespace EKART.Repositories
{
    public interface ISupplier
    {
        Task<string> CreateSupplier(SupplierDto suppliers);
        Task<bool> UpdateSupplier(int id,string address,string city,string postalCode,string country,string region);
        Task<List<SupplierDto>> GetAllSupplier();
        Task<List<SupplierDto>> GetSupplierByCountry(string country);
    }
}
