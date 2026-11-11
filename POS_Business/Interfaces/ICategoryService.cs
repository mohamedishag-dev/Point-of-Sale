using POS_DataAccess.Models;
using System.Collections.Generic;
using System.Data;

namespace POS_Business.Servicies
{
    public interface ICategoryService
    {
        DataTable GetAll();
        bool IsExists(int ID);
        bool Deactivate(int ID);
        bool Add(Category entity);
        bool Update(Category entity);
       // Category GetByCategoryID(int CategoryID);

    }

}
