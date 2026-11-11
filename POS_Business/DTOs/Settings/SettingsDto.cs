using System;

namespace POS_Business.DTOs.Settings
{
    public class SettingsDto
    {
        public string StoreName { get; set; }
        public string StorePhone { get; set; }
        public string StoreAddress { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal TaxRate { get; set; }
        public decimal LowStockThreshold { get; set; }
        public string ReceiptFooter { get; set; }
        public DateTime LastModified { get; set; }
    }
}
