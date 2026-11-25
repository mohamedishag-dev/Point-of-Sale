using POS_Business.Security;
using POS_Business.Security.Products;
using POS_Business.Validations;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public class ProductService : IProductService
    {
        internal ProductDto toDto(Product user)
        {
            return new ProductDto
            {
                ProductID = user.ProductID,
                CategoryID = user.CategoryID,
                UnitID = user.UnitID,
                ProductName = user.ProductName,
                SKU = user.SKU,
                Barcode = user.Barcode as string,
                Price = user.Price,
                CreatedAt = user.CreatedAt,
                ImagePath = user.ImagePath as string,
                CreatedBy = user.CreatedBy,
                Description = user.Description as string,

            };
        }
        internal Product toProduct(ProductDto productDto)
        {
            return new Product
            {
                ProductID = productDto.ProductID,
                CategoryID = productDto.CategoryID,
                UnitID = productDto.UnitID,
                ProductName = productDto.ProductName,
                SKU = productDto.SKU,
                Barcode = productDto.SKU,
                Price = productDto.Price,
                ImagePath = productDto.ImagePath,
                CreatedBy = productDto.CreatedBy,
                Description = productDto.Description,

            };
        }
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public DataTable GetAllProducts()
        {
            Session.Require(Perm.ProductsView);
            return _productRepository.GetAllProducts();

        }

        public bool DeleteProduct(int productID)
        {
            Session.Require(Perm.ProductsDelete);

            if (!_productRepository.IsProductExists(productID))
                return false;

            return (_productRepository.DeleteProduct(productID));
        }

        public bool IsProductExists(int productID)
        {

            return _productRepository.IsProductExists(productID);

        }

        public bool AddProduct(ProductDto productDto)
        {
            Session.Require(Perm.ProductsAdd);

            ProductValidator.Validate(productDto).ThrowIfInvalid();

            if (_productRepository.IsProductExistsWithProductName(productDto.ProductName))
                throw new ValidationException("المنتج موجود بالفعل");
         
            if (_productRepository.IsProductExistsWithBarcode(productDto.Barcode))
                throw new ValidationException("Barcode موجود بالفعل");

            Product product = toProduct(productDto);
            product.CreatedBy = Session.CurrentUser.UserID;

            product.ProductID = _productRepository.AddProduct(product);

            return (product.ProductID != -1);

        }

        public ProductDto GetProductByID(int productID)
        {
            Session.Require(Perm.ProductsView);

            Product product = _productRepository.GetProductByID(productID);

            if (product == null) return null;

            return toDto(product);
        }

        public bool UpdateProduct(ProductDto productDto)
        {
            Session.Require(Perm.ProductsEdit);
            ProductValidator.Validate(productDto).ThrowIfInvalid();
            Product product = toProduct(productDto);

            return _productRepository.UpdateProduct(product);

        }

        public bool IsProductExistsWithBarcode(string barcode)
        {
            return _productRepository.IsProductExistsWithBarcode(barcode);
        }

        public bool IsProductExistsWithProductName(string productName)
        {

            return _productRepository.IsProductExistsWithProductName(productName);

        }

    }
}
