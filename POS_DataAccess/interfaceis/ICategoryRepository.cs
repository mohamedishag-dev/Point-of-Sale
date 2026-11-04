using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.interfaceis
{
    public interface ICategoryRepository
    {
        DataTable GetAll();
        bool Deactivate(int ID);
        bool IsExists(int ID);
        int Add(Category entity);
        bool Update(Category entity);
        Category GetByCategoryID(int CategoryID);
    }
}
