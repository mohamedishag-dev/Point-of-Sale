using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.Models
{
    public class ProductBatches
    {        
        public int BatchID { get; set; }
        public int ProductID { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal ProductCost { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

    }
}
