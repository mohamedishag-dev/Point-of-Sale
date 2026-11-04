using System;

namespace POS_DataAccess.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int UnitID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
       
    }

}

