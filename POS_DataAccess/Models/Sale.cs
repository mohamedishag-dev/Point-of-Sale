using System;
using System.Collections.Generic;
using System.Linq;

namespace POS_DataAccess.Models
{
    public class Sale
    {
        public int SaleID { set; get; }
        public int CustomerID { set; get; }
        public int UserID { set; get; }
        public decimal SubTotal { set; get; }
        public decimal Discount { set; get; }
        public decimal Tax { set; get; }
        public decimal PaidAmount { set; get; }
        public byte SaleStatus { set; get; }
        public DateTime SaleDate { set; get; }
        public DateTime LastStatusDate { set; get; }
        public string Notes { set; get; }

        public decimal TotalAmount => (SubTotal - Discount + Tax);
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public List<Payment> Payments { get; set; } = new List<Payment>();

    }
}
