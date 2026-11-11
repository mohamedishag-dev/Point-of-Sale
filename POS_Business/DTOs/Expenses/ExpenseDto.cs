using System;

namespace POS_Business.DTOs.Expenses
{
    public class ExpenseDto
    {
        public int ExpenseID { get; set; }
        public string ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public int UserID { get; set; }
    }
}
