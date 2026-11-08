using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.Models
{
    public class SaleItems
    {
        public int SaleID { set; get; }
        public int ItemID { set; get; }
        public int BatchID { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal TotalAmount { set; get; }

    }
}
