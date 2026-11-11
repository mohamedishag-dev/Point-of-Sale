namespace POS_Business.DTOs.Purchases
{
    public class PurchaseItemDto
    {
        public int PurchaseItemID { set; get; }
        public int PurchaseID { set; get; }
        public int BatchID { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
    }
}
