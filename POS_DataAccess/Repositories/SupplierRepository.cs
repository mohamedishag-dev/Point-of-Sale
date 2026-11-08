using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.Repositories
{
    public class SupplierRepository: ISupplierRepository
    {

        DataTable GetAllSuppliers()
        {
            return new DataTable();
        }
        bool IsExists(string supplierName)    {
            return false;
        }
        int AddSupplier(Supplier supplier)
        {
            return 1;
        }
        bool DeleteSupplier(int supplierID)
        {
            return false;
        }
        bool UpdateSupplier(Supplier supplier)
        {
            return false;
        }
        Supplier GetSupplierById(int supplierID)
        {
            return new Supplier();
        }

    }
}
