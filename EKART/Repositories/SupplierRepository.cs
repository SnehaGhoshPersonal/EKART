using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using EKART.DTOs;
using EKART.Models;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repositories
{
    public class SupplierRepository:ISupplier
    {
        private readonly EKARTContext _context;
        public SupplierRepository(EKARTContext context)
        {
            _context = context;
        }
        public async Task<string> CreateSupplier(SupplierDto supplierDto)
        {
            Supplier supplier = new Supplier
            {
                SupplierId = supplierDto.SupplierId,
                CompanyName = supplierDto.CompanyName,
                ContactName = supplierDto?.ContactName,
                ContactTitle = supplierDto?.ContactTitle,
                Address = supplierDto?.Address,
                City = supplierDto?.City,
                Region = supplierDto?.Region,
                PostalCode = supplierDto?.PostalCode,
                Country = supplierDto?.Country,
                Phone = supplierDto?.Phone,
                Fax = supplierDto?.Fax,
                HpmePage = supplierDto?.HpmePage
            };
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return "Record Added Successfully";
        }

        public async Task<List<SupplierDto>> GetAllSupplier()
        {
            List<SupplierDto> supplierDtoList=new List<SupplierDto>();
            var supplier= await _context.Suppliers.ToListAsync();
            foreach(var s in supplier)
            {
                SupplierDto sd = new SupplierDto
                {
                    SupplierId = s.SupplierId,
                    CompanyName = s.CompanyName,
                    ContactName = s?.ContactName,
                    ContactTitle = s?.ContactTitle,
                    Address = s?.Address,
                    City = s?.City,
                    Region = s?.Region,
                    PostalCode = s.PostalCode,
                    Country = s?.Country,
                    Phone = s?.Phone,
                    Fax = s?.Fax,
                    HpmePage = s?.HpmePage
                };
                supplierDtoList.Add(sd);
            }
            return supplierDtoList;
        }
        public async Task<bool> UpdateSupplier(int id, string address, string city, string postalCode, string country, string region)
        {
            var supplierToUpdate = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == id);
            if (supplierToUpdate == null) return false;
            supplierToUpdate.Address= address;
            supplierToUpdate.City= city;    
            supplierToUpdate.PostalCode= postalCode;
            supplierToUpdate.Country= country;
            supplierToUpdate.Region = region;
            SupplierDto supplierDto = new SupplierDto
            {
                Address = supplierToUpdate?.Address,
                City = supplierToUpdate?.City,
                PostalCode = supplierToUpdate.PostalCode,
                Country = supplierToUpdate?.Country,
                Region=supplierToUpdate.Region
            };
            await _context.SaveChangesAsync();
            return true ;
        }
        public async Task<List<SupplierDto>> GetSupplierByCountry(string country)
        {
            var ans=await _context.Suppliers.Where(c=>c.Country==country).ToListAsync();
            List<SupplierDto> suppliers = new List<SupplierDto>();
            foreach (var s in ans)
            {
                SupplierDto sd = new SupplierDto
                {
                    SupplierId = s.SupplierId,
                    CompanyName = s.CompanyName,
                    ContactName = s?.ContactName,
                    ContactTitle = s?.ContactTitle,
                    Address = s?.Address,
                    City = s?.City,
                    Region = s?.Region,
                    PostalCode = s.PostalCode,
                    Country = s?.Country,
                    Phone = s?.Phone,
                    Fax = s?.Fax,
                    HpmePage = s?.HpmePage
                };
                suppliers.Add(sd);
            }
            return suppliers;
        }
    }
}
