using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        DataTable GetAllUnits();
        DataTable GetAllCategories();
        bool IsExists(int CategoryID);
        bool Deactivate(int CategoryID);
        int AddCategory(Category category);
        Unit GetByUnitName(string UnitName);
        bool UpdateCategory(Category category);
        Category GetByCategoryID(int CategoryID);
        Category GetByCategoryName(string CategoryName);
    }
}
