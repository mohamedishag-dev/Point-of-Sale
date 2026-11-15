using POS_Business.DTOs.Settings;
using POS_Business.Interfaces;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;

namespace POS_Business.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settings;

        public SettingsService(ISettingsRepository settings)
        {
            _settings = settings;
        }

        public SettingsDto Get()
        {
            POS_DataAccess.Models.Settings settings = _settings.Get();

            if (settings == null) return null;

            return new SettingsDto
            {
                StoreName = settings.StoreName,
                StorePhone = settings.StorePhone,
                StoreAddress = settings.StoreAddress,
                CurrencySymbol = settings.CurrencySymbol,
                TaxRate = settings.TaxRate,
                LowStockThreshold = settings.LowStockThreshold,
                ReceiptFooter = settings.ReceiptFooter,
                LastModified = settings.LastModified
            };

        }
        public bool Update(SettingsDto dto)
        {
            if (dto == null) return false;

            POS_DataAccess.Models.Settings settings = new POS_DataAccess.Models.Settings
            {
                StoreName = dto.StoreName,
                StorePhone = dto.StorePhone,
                StoreAddress = dto.StoreAddress,
                CurrencySymbol = dto.CurrencySymbol,
                TaxRate = dto.TaxRate,
                LowStockThreshold = dto.LowStockThreshold,
                ReceiptFooter = dto.ReceiptFooter,
                LastModified = dto.LastModified
            };

            return _settings.Update(settings);
        }

    }
}
