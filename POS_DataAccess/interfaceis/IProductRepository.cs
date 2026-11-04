using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.interfaceis
{
    public interface IProductRepository
    {
        DataTable GetAll();
        bool DeleteProduct(int productID);
        int AddNewProduct(Product product);
        bool UpdateProduct(Product product);
        bool IsProductExists(int productID);
        Product GetProductById(int productID);

    }
}
