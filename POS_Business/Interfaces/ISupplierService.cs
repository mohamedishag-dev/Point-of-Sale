using POS_Business.Security;
using System.Data;

namespace POS_Business.Interfaces
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
