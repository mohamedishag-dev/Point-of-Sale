using POS_Business.Security.Products;
using System.Data;

namespace POS_Business.Services
{
    public interface IProductService
    {
        DataTable GetAllProducts();
        bool DeleteProduct(int productID);
        bool AddProduct(ProductDto product);
        bool IsProductExists(int productID);
        bool UpdateProduct(ProductDto product);
        ProductDto GetProductByID(int productID);
        bool IsProductExistsWithBarcode(string Barcode);
        bool IsProductExistsWithProductName(string productName);
    }
}
