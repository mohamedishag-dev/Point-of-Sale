using System;

namespace POS_DataAccess.Models
{
    public class StockMovement
    {
        public int MovementID { set; get; }
        public int BatchID { set; get; }
        public int UserID { set; get; }
        public decimal Quantity { set; get; }
        public byte MovementType { set; get; }
        public int? PurchaseID { set; get; }
        public int? SaleID { set; get; }
        public int? ReturnID { set; get; }
        public int? DamageID { set; get; }
        public decimal TotalAmount { set; get; }
        public string Notes { set; get; }
        public DateTime CreatedAt { set; get; }

    }
}
