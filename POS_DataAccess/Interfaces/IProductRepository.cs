using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IProductRepository
    {
        DataTable GetAllProducts();
        bool DeleteProduct(int productID);
        int AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool IsProductExists(int productID);
        Product GetProductByID(int productID);
        bool IsProductExistsWithBarcode(string barcode);
        bool IsProductExistsWithProductName(string productName);

    }
}
