using System;

namespace POS_Business.Security.Sales
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int SaleID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserID { get; set; }
        public string Notes { get; set; }

    }
}
