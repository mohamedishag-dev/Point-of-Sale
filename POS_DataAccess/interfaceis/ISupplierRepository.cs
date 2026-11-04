using POS_DataAccess.Models;

namespace POS_DataAccess.interfaceis
{
    public interface ISupplierRepository 
    {
        int Add(Supplier entity);
        bool Update(Supplier entity);
        bool IsExists(string SupplierName);

    }

}
