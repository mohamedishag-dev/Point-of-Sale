namespace POS_DataAccess.Models
{
    public class PurchaseItem
    {
        public int PurchaseItemID { set; get; }
        public int PurchaseID { set; get; }
        public int BatchID { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }

    }
}
