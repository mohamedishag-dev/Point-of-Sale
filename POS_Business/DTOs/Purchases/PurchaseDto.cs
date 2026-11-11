using System;
using System.Collections.Generic;

namespace POS_Business.DTOs.Purchases
{
    public class PurchaseDto
    {
        public int PurchaseID { set; get; }
        public int SupplierID { set; get; }
        public int UserID { set; get; }
        public DateTime PurchaseDate { set; get; }
        public decimal PaidAmount { set; get; }
        public decimal TotalAmount { set; get; }

        public List<PurchaseItemDto> Items { set; get; }

    }
}
