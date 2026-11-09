using POS_Business.DTOs;
using POS_Business.interfaceis;
using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;
        public SupplierService(ISupplierRepository repository)
        {
            _repo = repository;
        }

        public DataTable GetAllSuppliers()
        {
            return _repo.GetAllSuppliers();
        }

        public bool IsExists(int supplierID)
        {
            if (supplierID == -1)
                return false;

            return _repo.IsExists(supplierID);
        
        }

        public bool IsExists(string supplierName)
        {
            if (string.IsNullOrEmpty(supplierName))
                return false;

            return _repo.IsExists(supplierName);
        }

        public bool AddSupplier(SupplierDto supplierDto)
        {
            if (supplierDto == null)
                return false;

            Supplier supplier = new Supplier
            {
                SupplierID = supplierDto.SupplierID,
                SupplierName = supplierDto.SupplierName,
                Address = supplierDto.Address,
                Phone = supplierDto.Phone,
                Email = supplierDto.Email,
                OpeningBalance = supplierDto.OpeningBalance
            };

            supplier.SupplierID = _repo.AddSupplier(supplier);
            return (supplier.SupplierID != -1);

        }

        public SupplierDto GetSupplierByID(int supplierID)
        {

            Supplier supplier = _repo.GetSupplierByID(supplierID);

            if (supplier == null)
                return null;

            return new SupplierDto
            {
                SupplierID = supplier.SupplierID,
                SupplierName = supplier.SupplierName,
                Address = supplier.Address,
                Phone = supplier.Phone,
                Email = supplier.Email,
                OpeningBalance = supplier.OpeningBalance
            };
        
        }

        public bool UpdateSupplier(SupplierDto supplierDto)
        {
        
            if (supplierDto == null)
                return false;
        
            Supplier supplier = new Supplier
            {
                SupplierID = supplierDto.SupplierID,
                SupplierName = supplierDto.SupplierName,
                Address = supplierDto.Address,
                Phone = supplierDto.Phone,
                Email = supplierDto.Email,
                OpeningBalance = supplierDto.OpeningBalance
            };

            return _repo.UpdateSupplier(supplier);

        }

        public bool DeleteSupplier(int supplierID) => _repo.DeleteSupplier(supplierID);


    }
}
