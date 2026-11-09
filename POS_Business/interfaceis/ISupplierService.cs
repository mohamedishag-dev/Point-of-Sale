using POS_Business.DTOs;
using System.Data;

namespace POS_Business.interfaceis
{
    public interface ISupplierService
    {
        DataTable GetAllSuppliers();
        bool IsExists(int supplierID);
        bool IsExists(string supplierName);
        bool DeleteSupplier(int supplierID);
        bool AddSupplier(SupplierDto supplier);
        bool UpdateSupplier(SupplierDto supplier);
        SupplierDto GetSupplierByID(int supplierID);

    }
}
