using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IExpenseRepository
    {
        DataTable GetAllExpenses();
        int AddExpense(Expense expense);
        bool UpdateExpense(Expense expense);
        bool DeleteExpense(int expenseID);

    }
}
