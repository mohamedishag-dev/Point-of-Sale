using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        DataTable GetAll();
        int Add(Category category);
        bool IsExists(int CategoryID);
        bool Update(Category category);
        bool Deactivate(int CategoryID);
        Category GetByCategoryID(int CategoryID);

    }
}
