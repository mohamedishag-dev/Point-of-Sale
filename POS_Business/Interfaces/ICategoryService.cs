using POS_Business.DTOs.Products;
using System.Data;

namespace POS_Business.Servicies
{
    public interface ICategoryService
    {
        DataTable GetAllUnits();
        DataTable GetAllCategories();
        bool IsExists(int CategoryID);
        bool Deactivate(int CategoryID);
        bool AddCategory(CategoryDto Category);
        UnitDto GetByUnitName(string UnitName);
        bool UpdateCategory(CategoryDto Category);
        CategoryDto GetByCategoryID(int CategoryID);
        CategoryDto GetByCategoryName(string CategoryName);

    }

}
