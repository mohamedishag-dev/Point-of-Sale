using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using POS_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repo = new ProductRepository();

        public DataTable GetAllProducts()
        {
            
            return _repo.GetAllProducts();

        }

        public bool DeleteProduct(int productID)
        {
            if (_repo.IsProductExists(productID))
                return (_repo.DeleteProduct(productID));
           
            return false;
      
        }

        public bool AddNewProduct(Product product)
        {
            product.ProductID = _repo.AddNewProduct(product);

            return (product.ProductID != -1);

        }

        public bool IsProductExists(int productID)
        {
            
            return _repo.IsProductExists(productID);

        }

        public bool UpdateProduct(Product product)
        {
        
            return _repo.UpdateProduct(product);
       
        }

        public  Product GetProductById(int productID)
        {
            
            return _repo.GetProductById(productID);

        }


    }
}
