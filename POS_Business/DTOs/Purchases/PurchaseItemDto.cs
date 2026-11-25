namespace POS_Business.Security.Purchases
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
