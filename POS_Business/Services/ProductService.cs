using POS_Business.DTOs.Products;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using POS_DataAccess.Repositories;
using System.Data;

namespace POS_Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;// = new ProductRepository();

        public ProductService(IProductRepository repo)
        {
            _repo = repo;

        }

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

        public bool IsProductExists(string productName)
        {

            return _repo.IsProductExists(productName);

        }

        public bool UpdateProduct(Product product)
        {

            return _repo.UpdateProduct(product);

        }

        public ProductDto GetProductByID(int productID)
        {
            Product product = _repo.GetProductById(productID);

            if (product == null)
                return null;

            return new ProductDto
            {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                UnitID = product.UnitID,
                ProductName = product.ProductName,
                SKU = product.SKU,
                Barcode = product.Barcode,
                Price = product.Price,
                ImagePath = product.ImagePath as string,
                Description = product.Description,
                CreatedBy = product.CreatedBy
            };


        }
    }
}
