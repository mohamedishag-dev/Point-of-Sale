using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {

        public DataTable GetAllSuppliers()
        {
            return new DataTable();
        }

        public bool IsExists(string supplierName)
        {
            return IsExists(supplierName);
        }

        public int AddSupplier(Supplier supplier)
        {
            return 1;
        }

        public bool DeleteSupplier(int supplierID)
        {
            return DeleteSupplier(supplierID);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            return UpdateSupplier(supplier);
        }

        public Supplier GetSupplierById(int supplierID)
        {
            return GetSupplierById(supplierID);
        }

    }

}
