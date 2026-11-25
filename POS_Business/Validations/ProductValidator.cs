using POS_Business.Security.Products;

namespace POS_Business.Validations
{
    public static class ProductValidator
    {
        public static ValidationResult Validate(ProductDto product)
        {
            var result = new ValidationResult();

            if (product == null)
            {
                result.Add("بيانات المنتج غير موجودة");
                return result;
            }


            if (string.IsNullOrWhiteSpace(product.ProductName))
                result.Add("اسم المنتج مطلوب");

            if (string.IsNullOrWhiteSpace(product.SKU))
                result.Add("كود الصنف (SKU) مطلوب");

            if (product.CategoryID <= 0)
                result.Add("يجب اختيار تصنيف المنتج");

            if (product.UnitID <= 0)
                result.Add("يجب اختيار وحدة قياس المنتج");

            if (product.Price <= 0)
                result.Add("يجب أن يكون سعر المنتج أكبر من صفر");

            return result;
        }
    }

}
