using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.Services
{
    public interface IProductService
    {
        DataTable GetAll();
        bool DeleteProduct(int productID);
        bool AddNewProduct(Product product);
        bool IsProductExists(int productID);
        bool UpdateProduct(Product product);
        Product GetProductById(int productID);

    }
}
