using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.Models
{
    public class Payment
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
