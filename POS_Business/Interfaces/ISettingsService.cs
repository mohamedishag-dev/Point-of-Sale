using POS_Business.Security.Settings;

namespace POS_Business.Interfaces
{
    public interface ISettingsService
    {
        SettingsDto Get();
        bool Update(SettingsDto settings);

    }
}

