using POS_Business.DTOs.Settings;

namespace POS_Business.Interfaces
{
    public interface ISettingsService
    {
        SettingsDto Get();
        bool Update(SettingsDto settings);

    }
}

