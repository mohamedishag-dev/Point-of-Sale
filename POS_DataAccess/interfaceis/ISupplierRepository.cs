using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.interfaceis
{
    public interface ISupplierRepository 
    {
        DataTable GetAllSuppliers();
        bool IsExists(string supplierName);
        int AddSupplier(Supplier supplier);
        bool DeleteSupplier(int supplierID);
        bool UpdateSupplier(Supplier supplier);
        Supplier GetSupplierById(int supplierID);

    }

}
