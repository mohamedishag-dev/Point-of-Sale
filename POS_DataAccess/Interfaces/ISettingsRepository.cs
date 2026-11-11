using POS_DataAccess.Models;

namespace POS_DataAccess.Interfaces
{

    public interface ISettingsRepository
    {
        Settings Get();
        bool Update(Settings s);
    }

}
