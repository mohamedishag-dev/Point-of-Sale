using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.DTOs
{
    public class SaleDto
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
        public decimal TotalAmount { set; get; }
        public string Notes { set; get; }
    }
}
